using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy_move : MonoBehaviour
{
    public int speed;
    public bool MoveRight;
    [Range(0, 8f)] [SerializeField] private float left_limit = .05f;
    [Range(0, 8f)] [SerializeField] private float right_limit = .05f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

    public Enemy enemy;
    public Animator anim;
    public Rigidbody2D rigidbody;
    public float timedelay = 2f;
    
    float time_idle = 0f;
    bool idle = false;
    Vector2 m_velocity = Vector2.zero;

    float left_x, right_x;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        enemy = gameObject.GetComponent<Enemy>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        left_x = transform.position.x - left_limit;
        right_x = transform.position.x + right_limit;
        time_idle = Time.time;
    }
    // Update is called once per frame
    void FixedUpdate()
    {   
        
        if(enemy.currentHealth > 0)
        {
           
            if (Time.time < (time_idle + timedelay + 5))
            {
                idle = false;
              
            }
            else
            {
                idle = true;
                if ((Time.time - timedelay - 3) > (time_idle + timedelay))
                {
                    
                    time_idle = Time.time;
                }
            }
            if (transform.position.x >= right_x)
            {
                
                MoveRight = false;

            }
            if (transform.position.x <= left_x)
            {
                MoveRight = true;
            }

            
            if (MoveRight && !idle)
            {
                
                rigidbody.velocity = Vector2.SmoothDamp(rigidbody.velocity, new Vector2(1 * speed * Time.fixedDeltaTime * 10f ,rigidbody.velocity.y), ref m_velocity, m_MovementSmoothing);
                //transform.Translate(2 * speed * Time.deltaTime, 0, 0);
                transform.localScale = new Vector2(2, 2);
            }
            if(!MoveRight && !idle)
            {
                rigidbody.velocity = Vector2.SmoothDamp(rigidbody.velocity, new Vector2(-1 * speed * Time.fixedDeltaTime * 10f, rigidbody.velocity.y), ref m_velocity, m_MovementSmoothing);
                //transform.Translate(-2 * speed * Time.deltaTime, 0, 0);
                transform.localScale = new Vector2(-2, 2);
            }
            anim.SetBool("IsIdle", idle);
        }
    }
}
