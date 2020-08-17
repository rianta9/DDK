using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Trong đối tượng demon, tạo 1 gameobject...add vào đó */
public class DemonAutoAttaking : MonoBehaviour
{
    public int damage = 5;
    public float delayAttackTime = 1.0f; // thời gian đợi mỗi lần di chuyển
    public float waitTime;
    public bool isAttaking = false;
    public Animator anim;


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInParent<Animator>();
        this.waitTime = delayAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isAttaking", isAttaking); // bật animation di chuyển
        if (isAttaking)
        {
            this.waitTime = this.waitTime - Time.deltaTime; // cập nhật thời gian đợi còn lại
            if (this.waitTime <= 0) 
            { // nếu đến lúc di chuyển
                Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                player.SendMessage("Damage", damage); // gửi damage cho player
                this.waitTime = delayAttackTime; // cập nhật lại delayTime cho lần sau
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttaking = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttaking = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttaking = false;
        }
    }
}
