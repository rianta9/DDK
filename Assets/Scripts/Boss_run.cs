using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Boss_run : StateMachineBehaviour
{
    public float speed = 2.5f; 
    public float AttackRange = 1.5f;

    Transform player;
    Rigidbody2D r2;
    Boss boss;
     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        r2 = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 targer = new Vector2(player.position.x, r2.position.y);
       
        Vector2 newpos = Vector2.MoveTowards(r2.position, targer, speed * Time.fixedDeltaTime);
    
        r2.MovePosition(newpos);

        if(Vector2.Distance(player.position, r2.position) <= AttackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

     //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
