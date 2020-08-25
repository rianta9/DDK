using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public Transform Point_Attack;
    [SerializeField] private LayerMask WhatIsPlayer;
    public Animator animator;
    public BasicEnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = gameObject.GetComponent<BasicEnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
      
        Collider2D colliders = Physics2D.OverlapBox(Point_Attack.position, new Vector3(2.5f, 1,0),0, WhatIsPlayer);
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
        Gizmos.DrawWireCube(Point_Attack.position,new Vector3(5,1,0));

        //Gizmos.DrawFrustum(Point_Attack.position, 20,10,2,0.5f);
    }
    void resetAttackNotMove()
    {
        enemyController.setAttackNotMove(1);
    }
    
    
}
