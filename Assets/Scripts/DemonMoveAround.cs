using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 Demon tự động di chuyển qua về một vị trí(Theo hướng ngang).
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
    public int faceDirection = 1; // hướng di chuyển ban đầu. Nếu mặt demon hướng về bên trái thì set -1, ngược lại set 1

    public bool isRunning = true;

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
        anim = GetComponent<Animator>();
        control = FindObjectOfType<AutoControlDemon>();
    }

    public void Death()
    {
        control.SetDemonDied(true);
        Destroy(gameObject);
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
                Death();
            }
        }

        else
        {
            delayRunTime -= Time.deltaTime; // cập nhật thời gian đợi còn lại
            anim.SetBool("isRunning", isRunning); // bật animation tấn công
            if (delayRunTime <= 0) // nếu hết thời gian đợi thì cho phép tấn công
            { // nếu đến lúc di chuyển
                isRunning = true;
                delayRunTime = 0.2f; // cập nhật lại delayTime cho lần sau

                /* di chuyển*/

                // cập nhật hướng đi animate
                Vector3 rem = transform.localScale;
                if (faceDirection == -1) rem.x = -(Mathf.Abs(rem.x)); // mặt hướng về bên trái thì đi về bên trái
                else rem.x = Mathf.Abs(rem.x); // mặt hướng về bên phải
                transform.localScale = rem;

                // cập nhật vị trí demon
                transform.position += new Vector3(faceDirection * 0.5f, 0, 0);

                // tăng movelength lên 1 khoảng 0.2
                movedLength += 0.2f;

                if (movedLength >= maxLength)
                { // nếu khoảng cách di chuyển đã tối đa
                    isRunning = false; // bật animation đứng yên
                    delayRunTime = Random.Range(2, 5); // cho demon đứng yên 2 đến 5s 
                    faceDirection *= -1; // cho demon đổi hướng
                    maxLength = 6; // cập nhật maxLength
                    movedLength = 0; // reset movedlength
                }
            }
        }
    }
}
