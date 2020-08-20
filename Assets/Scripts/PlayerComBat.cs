using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComBat : MonoBehaviour
{
    public Animator animator;
    public Transform attackpoint;
    public LayerMask enemyLayers;
    public PlayerMoving player;

    public Rigidbody2D rigidbody;
    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public float attackRate = 2f;
    public float timeattack = 1.2f;

    float nextAttackTime;

    bool attacking = false;
    // Update is called once per frame
    private void Start()
    {
        nextAttackTime = timeattack;
        player = gameObject.GetComponent<PlayerMoving>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Z) && !attacking && player.isGrounded())
        {
            attacking = true;
            nextAttackTime = timeattack;
        }
        if (attacking)
        {
            if(nextAttackTime > 0)
            {
                nextAttackTime -= Time.deltaTime;
            }
            else
            {
                attacking = false;
            }
        }
        
        animator.SetBool("Attack",attacking);
    }
    void Attack()
    {
        if (player.get_faceright())
        {
            rigidbody.AddForce(Vector2.right * 200f);
        }
        else
        {
            rigidbody.AddForce(Vector2.left * 200f);
        }
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in colliders)
        {
            enemy.SendMessageUpwards("TakeDamage", attackDamage);
            //enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    //ve duong tron cho diem point attack
    private void OnDrawGizmosSelected()
    {
        if(attackpoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
    public void SkipSkill()
    {
        attacking = false;
    }
}
