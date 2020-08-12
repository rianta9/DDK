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
    public float delayTime; // thời gian đợi mỗi lần di chuyển
    public float movedLength; // khoảng cách di chuyển so với vị trí ban đầu
    public float maxLength; // khoảng cách di chuyển tối đa
    public int faceDirection; // hướng di chuyển. Nếu animation hướng về bên trái thì set -1, ngược lại set 1
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        delayTime = 0.2f;
        movedLength = 0;
        faceDirection = 1; // mặc định mặt hướng về bên phải
        maxLength = 3; // ban đầu di chuyển lên tối đa 3 đơn vị
    }

    // Update is called once per frame
    void Update()
    {
        delayTime -= Time.deltaTime; // cập nhật thời gian đợi còn lại
        if (delayTime <= 0) // nếu hết thời gian đợi thì cho phép di chuyển
        { // nếu đến lúc di chuyển
            anim.SetBool("isRunning", true); // bật animation di chuyển
            delayTime = 0.2f; // cập nhật lại delayTime cho lần sau

            /* di chuyển*/

            // cập nhật hướng đi animate
            Vector3 rem = transform.localScale;
            if (faceDirection == -1) rem.x = -(Mathf.Abs(rem.x)); // mặt hướng về bên trái
            else rem.x = Mathf.Abs(rem.x); // mặt hướng về bên phải
            transform.localScale = rem;

            // cập nhật vị trí vật thể
            transform.position += new Vector3(faceDirection * 0.2f, 0, 0);

            // tăng movelength lên 1 khoảng 0.2
            movedLength += 0.2f;

            if (movedLength >= maxLength)
            { // nếu khoảng cách di chuyển đã tối đa
                anim.SetBool("isRunning", false); // bật animation đứng yên
                delayTime = Random.Range(2, 5); // cho vật thể đứng yên 2 đến 5s 
                faceDirection *= -1; // cho vật thể đổi hướng
                maxLength = 6; // cập nhật maxLength
                movedLength = 0; // reset movedlength
            }
        }
    }
}
