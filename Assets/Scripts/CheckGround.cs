using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public PlayerMoving player;
    public CircleCollider2D box;
    //const float k_GroundedRadius = .2f;
    
 

    private void Start()
    {
        player = gameObject.GetComponentInParent<PlayerMoving>();
        box = gameObject.GetComponentInParent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            player.swapgroud(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.isTrigger == false)
        {
            player.swapgroud(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            player.swapgroud(false);
        }
    }
}
