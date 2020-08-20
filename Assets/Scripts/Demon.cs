using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Demon tự động di chuyển qua về một vị trí(Theo hướng ngang).
 Add script này vào những vật thể game mong muốn.
 Nhớ set các thuộc tính cần thiết cho demon trong unity.
 Nhớ set hướng nhìn(faceDirection) cho demon trong unity.
 */
public class Demon : MonoBehaviour
{
    public int blood = 200;
    private float delayDieTime; // thời gian chờ animation death

    public float delayTime; // thời gian đợi mỗi lần di chuyển
    public float movedLength; // khoảng cách di chuyển so với vị trí ban đầu
    public float maxLength; // khoảng cách di chuyển tối đa
    public int moveDirection; // hướng di chuyển. Nếu animation hướng về bên trái thì set -1, ngược lại set 1

    public bool isRunning;

    public Animator anim;
    AutoControlDemon control;

    public void setBlood(int blood)
    {
        this.blood = blood;
    }

    public int getBlood()
    {
        return this.blood;
    }

    public void Damage(int damage)
    {
        this.blood -= damage;
    }


    private void Awake()
    {
        delayDieTime = 1.0f;

        delayTime = 0.2f;
        movedLength = 0;
        moveDirection = 1; // mặc định mặt hướng về bên phải
        maxLength = 3; // ban đầu di chuyển lên tối đa 3 đơn vị

        isRunning = true;

        anim = GetComponent<Animator>();
        control = FindObjectOfType<AutoControlDemon>();
    }

    void Update()
    {
        if (this.blood <= 0)
        {
            anim.SetBool("isDied", true);
            //anim.SetBool("isRunning", false); // bật animation di chuyển
            delayDieTime -= Time.deltaTime;
            if (delayDieTime <= 0) 
            {
                control.SetDemonDied(true);
                Destroy(gameObject);
            }
        }

        

        else
        {
            delayTime -= Time.deltaTime; // cập nhật thời gian đợi còn lại
            anim.SetBool("isRunning", isRunning); // bật animation di chuyển
            if (delayTime <= 0) // nếu hết thời gian đợi thì cho phép di chuyển
            { // nếu đến lúc di chuyển
                isRunning = true;
                delayTime = 0.2f; // cập nhật lại delayTime cho lần sau

                /* di chuyển*/

                // cập nhật hướng đi animate
                Vector3 rem = transform.localScale;
                if (moveDirection == -1) rem.x = -(Mathf.Abs(rem.x)); // mặt hướng về bên trái
                else rem.x = Mathf.Abs(rem.x); // mặt hướng về bên phải
                transform.localScale = rem;

                // cập nhật vị trí demon
                transform.position += new Vector3(moveDirection * 2f, 0, 0);

                // tăng movelength lên 1 khoảng 0.2
                movedLength += 0.2f;

                if (movedLength >= maxLength)
                { // nếu khoảng cách di chuyển đã tối đa
                    isRunning = false; // bật animation đứng yên
                    delayTime = Random.Range(2, 5); // cho demon đứng yên 2 đến 5s 
                    moveDirection *= -1; // cho demon đổi hướng
                    maxLength = 6; // cập nhật maxLength
                    movedLength = 0; // reset movedlength
                }
            }
        }
    }
}
