using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    
    [SerializeField] private float GroundcheckDistance = 0, WallCheckDistance = 0, movementSpeed = 0;
    [SerializeField] private Transform groundcheck = null, wallcheck = null;
    [SerializeField] private LayerMask WhatIsGround;
    [Range(0, 8f)] [SerializeField] private float left_limit = .05f;
    [Range(0, 8f)] [SerializeField] private float right_limit = .05f;
    [SerializeField] private int MaxHealth;
    private int currentHealth;

    public Transform Enemy;
    public Rigidbody2D r2;
    public bool isBound;

    private bool isGround, isWall , faceright = true;
    Vector2 velocity_temp;
    private int ChieuMove = 1;

    private float Left = 0, right = 0,CurrentPotion;
    private int AttackNotMove = 1;
    private bool CanChangeFlip = true;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = gameObject.GetComponent<Transform>();
        r2 = gameObject.GetComponent<Rigidbody2D>();
        CurrentPotion = Enemy.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Left = CurrentPotion - left_limit;
        right = CurrentPotion + right_limit;
        if (!isBound)
        {
            // Raycast (vi tri bat dau , huong, khoan cach, nhung layer xac dinh)
            isGround = Physics2D.Raycast(groundcheck.position, Vector2.down, GroundcheckDistance, WhatIsGround);
            isWall = Physics2D.Raycast(wallcheck.position, Vector2.down, WallCheckDistance, WhatIsGround);
            if (!isGround || isWall)
            {
                Flip();
            }
            Move();
        }
        else
        {
            // Raycast (vi tri bat dau , huong, khoan cach, nhung layer xac dinh)
            isGround = Physics2D.Raycast(groundcheck.position, Vector2.down, GroundcheckDistance, WhatIsGround);
            isWall = Physics2D.Raycast(wallcheck.position, Vector2.down, WallCheckDistance, WhatIsGround);
            if (!isGround || isWall)
            {
                Flip();
            }
            if(Enemy.transform.position.x < Left && !faceright)
            {
                Flip();
            }
            if(Enemy.transform.position.x > right && faceright)
            {
                Flip(); 
            }
            Move();
        }

    }

    void Move()
    {
        velocity_temp.Set(movementSpeed * ChieuMove * AttackNotMove,r2.velocity.y);
        r2.velocity = velocity_temp;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundcheck.position, new Vector2(groundcheck.position.x,groundcheck.position.y - GroundcheckDistance));
        Gizmos.DrawLine(wallcheck.position, new Vector2(wallcheck.position.x + WallCheckDistance, wallcheck.position.y));
    }
    public void Flip()
    {
        if (CanChangeFlip)
        {
            Enemy.Rotate(0, 180, 0);
            ChieuMove *= -1;
            faceright = !faceright;
        }
    }
    public void setAttackNotMove(int e)
    {
        AttackNotMove = e;
    }
    public bool getFaceright()
    {
        return faceright;
    }
    public void CanChangeTrue()
    {
        CanChangeFlip = true;
    }
    public void CanChangeFalse()
    {
        CanChangeFlip = false;
    }
}
