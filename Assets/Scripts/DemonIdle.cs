using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Script này áp dụng cho các demon đứng yên một chỗ.
 Khuôn mặt demon sẽ hướng về vị trí người chơi.
 Nếu người chơi nằm trong phạm vi công kích, demon sẽ chủ động công kích.
 Nhớ set hướng nhìn(faceDirection) cho demon trong unity.
 */
public class DemonIdle : MonoBehaviour
{
    public int blood = 200;

    public float delayDieTime = 1f; // thời gian chờ animation death

    public float movedLength = 0; // khoảng cách di chuyển so với vị trí ban đầu
    public float maxLength = 3; // khoảng cách di chuyển tối đa
    public int faceDirection = -1; //  Nếu mặt demon hướng về bên trái thì set -1, ngược lại set 1
    public int moveDirection = 1;
    Player player;
    Area area;


    public Animator anim;

    public void setBlood(int blood)
    {
        this.blood = blood;
    }

    public int getBlood()
    {
        return this.blood;
    }

    public void TakeDamage(int damage)
    {
        this.blood -= damage;
    }


    private void Awake()
    {
        anim = GetComponent<Animator>();
        moveDirection = faceDirection;
        player = FindObjectOfType<Player>();
        area = GetComponentInChildren<Area>();
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        Vector3 rem = transform.localScale;
        // mặt hướng ngược lại so với faceDirection
        if (moveDirection != faceDirection) rem.x = -(Mathf.Abs(rem.x)); 
        else rem.x = Mathf.Abs(rem.x); // mặt hướng cùng với faceDirection
        transform.localScale = rem;

        if (this.blood <= 0)
        {
            anim.SetBool("isDied", true);
            //anim.SetBool("isRunning", false); // bật animation di chuyển
            delayDieTime -= Time.deltaTime;
            if (delayDieTime <= 0)
            {
                Death();
            }
        }
        if (area.isInRange)
        {
            if (player.transform.position.x > gameObject.transform.position.x)
                moveDirection = 1;
            else moveDirection = -1;
        }
    }
}
