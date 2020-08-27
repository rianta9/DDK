using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public Transform Point_Attack;
    public Transform AttackRange_is;
    public float AttackRange;
    public int Damage_enemy;

    [SerializeField] private LayerMask WhatIsPlayer;
    public Animator animator;
    public BasicEnemyController enemyController;
    public Rigidbody2D r2;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = gameObject.GetComponent<BasicEnemyController>();
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
        Collider2D colliders = Physics2D.OverlapBox(AttackRange_is.position, new Vector3(3, 1,0),0, WhatIsPlayer);
        if (colliders != null)
        {
            animator.SetBool("Attack",true);
            enemyController.setAttackNotMove(0);
            if (colliders.transform.position.x > enemyController.transform.position.x && !enemyController.getFaceright())
            {
                enemyController.Flip();
            }
            
            if (colliders.transform.position.x < enemyController.transform.position.x && enemyController.getFaceright())
            {
                enemyController.Flip();
            }
            

        }
        else
        {
            animator.SetBool("Attack", false);
            
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        if (Point_Attack == null)
            return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(AttackRange_is.position,new Vector3(5,1,0));
        Gizmos.DrawWireSphere(Point_Attack.position, AttackRange);

        //Gizmos.DrawFrustum(Point_Attack.position, 20,10,2,0.5f);
    }
    void resetAttackNotMove()
    {
        enemyController.setAttackNotMove(1);
    }
    void Attack()
    {
        if (enemyController.getFaceright())
        {
            r2.AddForce(Vector2.right * 200f);
        }
        else
        {
            r2.AddForce(Vector2.left * 200f);
        }
        Collider2D colliders = Physics2D.OverlapCircle(Point_Attack.position, AttackRange, WhatIsPlayer);
       
        if(colliders != null)
        {
            colliders.SendMessageUpwards("TakeDamage", Damage_enemy);
        }
       
    }
   
}
