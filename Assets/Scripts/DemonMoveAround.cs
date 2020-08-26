using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 Demon tự động di chuyển qua về một vị trí(Theo hướng ngang).
 Nếu player chạm vào demon này, demon sẽ đánh
 Add script này vào những vật thể game mong muốn.
 Nếu người chơi nằm trong phạm vi công kích, demon sẽ chủ động công kích.
 Nhớ set các thuộc tính cần thiết cho demon trong unity.
 Nhớ set hướng nhìn(faceDirection) cho demon trong unity.
 */

public class DemonMoveAround : MonoBehaviour
{
    public int blood = 200;

    public float delayDieTime = 1f; // thời gian chờ animation death
    public float delayRunTime = 0.2f; // thời gian đợi mỗi lần di chuyển

    public float movedLength = 0; // khoảng cách di chuyển so với vị trí ban đầu
    public float maxLength = 3; // khoảng cách di chuyển tối đa
    public int faceDirection = 1; //  Nếu mặt demon hướng về bên trái thì set -1, ngược lại set 1
    public int moveDirection = 1; // Hướng di chuyển. Nếu muốn đầu tiên demon di chuyển về bên trái thì set -1, ngược lại set 1

    public bool isRunning = true;

    public Animator anim;
    Area area;
    Player player;

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
        area = GetComponentInChildren<Area>();
        player = FindObjectOfType<Player>();
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
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

        else
        {
            if (area && area.isInRange)
            {
                if (player.transform.position.x > gameObject.transform.position.x)
                    moveDirection = 1;
                else moveDirection = -1;
            }

            delayRunTime -= Time.deltaTime; // cập nhật thời gian đợi còn lại
            anim.SetBool("isRunning", isRunning); // bật animation tấn công
            if (delayRunTime <= 0) // nếu hết thời gian đợi thì cho phép tấn công
            { // nếu đến lúc di chuyển
                isRunning = true;
                delayRunTime = 0.2f; // cập nhật lại delayTime cho lần sau

                /* di chuyển*/

                Vector3 rem = transform.localScale;
                // mặt hướng ngược lại so với faceDirection
                if (moveDirection != faceDirection) rem.x = -(Mathf.Abs(rem.x)); 
                else rem.x = Mathf.Abs(rem.x); // mặt hướng cùng với faceDirection
                transform.localScale = rem;

                // cập nhật vị trí demon
                transform.position += new Vector3(moveDirection * 0.5f, 0, 0);

                // tăng movelength lên 1 khoảng 0.2
                movedLength += 0.2f;

                

                if (movedLength >= maxLength)
                { // nếu khoảng cách di chuyển đã tối đa
                  // cập nhật hướng đi animate
                    isRunning = false; // bật animation đứng yên
                    delayRunTime = Random.Range(2, 5); // cho demon đứng yên 2 đến 5s 
                    moveDirection *= -1; // cho demon đổi hướng
                    maxLength = 6; // cập nhật maxLength
                    movedLength = 0; // reset movedlength
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isRunning = false; // set trạng thái ko di chuyển
            delayRunTime = int.MaxValue; // cho demon dừng di chuyển
        }
        else if(!collision.gameObject.CompareTag("Enemy")) // quay lui khi gặp chướng ngại vật
        {
            isRunning = true;
            moveDirection *= -1;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isRunning = false; // set trạng thái ko di chuyển
            delayRunTime = int.MaxValue; // cho demon dừng di chuyển
        }
        else if (!collision.gameObject.CompareTag("Enemy")) // quay lui khi gặp chướng ngại vật
        {
            isRunning = true;
            moveDirection *= -1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isRunning = true; // set trạng thái di chuyển
            delayRunTime = 0.5f; // cho demon đứng yên 1s rồi tiếp tục di chuyển
        }
    }
}
