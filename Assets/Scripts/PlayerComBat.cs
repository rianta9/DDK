using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComBat : MonoBehaviour
{
    public Animator animator;
    public Transform attackpoint;
    public LayerMask enemyLayers;
    public PlayerMoving player;

    public Rigidbody2D r2;
    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public float attackRate = 2f;


    public bool attacking;
    //private bool CanAttack;



    public float lastClickedTime;
    public float MaxComboTime;
    public static int hitkick = 0;

    [Header("Sound Attakc")]
    public bool soundAttack = false;

    public PauseMenu pause;
    // Update is called once per frame
    private void Awake()
    {
        
        player = gameObject.GetComponent<PlayerMoving>();
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {


        if (Time.time - lastClickedTime > MaxComboTime)
        {
            hitkick = 0;
            //CanAttack = true;
        }
        if(hitkick < 4)
        {
            if (Input.GetKeyDown(KeyCode.Z) && player.isGrounded() && PauseMenu.GameIsPaused == false)
            {
                lastClickedTime = Time.time;
                hitkick++;
                if (hitkick == 1)
                {
                    TanCong();
                }
                hitkick = Mathf.Clamp(hitkick, 0, 4);
            }
        }
        //if(Time.time >= nextAttackTime) { }
        //if (Input.GetKeyDown(KeyCode.Z) && player.isGrounded())
        //{
        //    TanCong();
        //    Debug.Log("1");

        //}






    }
    void Attack()
    {
        soundAttack = true;
        if (player.get_faceright())
        {
            r2.AddForce(Vector2.right * 100f);
        }
        else
        {
            r2.AddForce(Vector2.left * 100f);
        }
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in colliders)
        {
            enemy.SendMessageUpwards("TakeDamage", attackDamage);
            
        }
        
    }
    void Attack2()
    {
        soundAttack = true;
        if (player.get_faceright())
        {
            r2.AddForce(Vector2.right * 200f);
        }
        else
        {
            r2.AddForce(Vector2.left * 200f);
        }
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in colliders)
        {
            enemy.SendMessageUpwards("TakeDamage", attackDamage + (attackDamage*0.1f));

        }

    }
    void Attack3()
    {
        soundAttack = true;
        if (player.get_faceright())
        {
            r2.AddForce(Vector2.right * 250f);
        }
        else
        {
            r2.AddForce(Vector2.left * 250f);
        }
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in colliders)
        {
            enemy.SendMessageUpwards("TakeDamage", attackDamage + (attackDamage*0.2f));

        }

    }

    void TanCong()
    {

        animator.SetBool("Atk1", true);
        attacking = true;
    }
    void TanCong2()
    {

        //animator.SetBool("Atk2", true);
        attacking = true;
    }
    void TanCong3()
    {
        //animator.SetBool("Atk3", true);
 
        attacking = true;

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
