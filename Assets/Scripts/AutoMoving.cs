using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    Add script này vào object để object tự động di chuyển
    Script này dùng cho những object di chuyển qua về một điểm
    Mặc định demon hướng mặt về bên phải
*/


public class AutoMoving : MonoBehaviour
{
    public float delayRunTime = 0.2f; // thời gian đợi mỗi lần di chuyển
    public float movedLength = 0; // khoảng cách đã di chuyển
    public float maxLength = 5; // khoảng cách di chuyển tối đa
    public int faceDirection; // hướng di chuyển. Nếu animation hướng về bên trái thì set -1, ngược lại set 1

    // Update is called once per frame
    void Update()
    {
        delayRunTime -= Time.deltaTime; // cập nhật thời gian đợi còn lại
        if (delayRunTime <= 0) // nếu hết thời gian đợi thì cho phép di chuyển
        { // nếu đến lúc di chuyển
            delayRunTime = 0.2f; // cập nhật lại delayTime cho lần sau
            /* di chuyển*/
            // cập nhật vị trí
            transform.position += new Vector3(faceDirection * 0.5f, 0, 0);
            // tăng movelength lên 1 khoảng 0.2
            movedLength += 0.2f;

            if (movedLength >= maxLength)
            { // nếu khoảng cách di chuyển đã tối đa
              // cập nhật hướng đi animate
                Vector3 rem = transform.localScale;
                if (faceDirection == -1) rem.x = -(Mathf.Abs(rem.x)); // mặt hướng về bên trái thì đi về bên trái
                else rem.x = Mathf.Abs(rem.x); // mặt hướng về bên phải
                transform.localScale = rem;

                delayRunTime = Random.Range(2, 5); // cho demon đứng yên 2 đến 5s 
                faceDirection *= -1; // cho demon đổi hướng
                maxLength = 5; // cập nhật maxLength
                movedLength = 0; // reset movedlength


            }
        }
    }
}
