using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    public float speed = 0.05f, changeDirection = -1;
    Vector3 move;
    
    void Start()
    {
        move = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move.x += speed * changeDirection;
        transform.position = move;
    }

    private void OnCollisionEnter2D(Collision2D another)
    { // nếu chạm vào một colider có tag là Ground1 thì quay đầu
        if (another.gameObject.CompareTag("Ground"))
        {
            changeDirection *= -1;
        }
    }
}
