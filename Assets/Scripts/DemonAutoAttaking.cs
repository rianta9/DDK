using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Trong đối tượng demon, tạo 1 gameobject...add script này vào đó */
public class DemonAutoAttaking : MonoBehaviour
{
    public int damage = 5;
    public float delayAttackTime = 1.0f; // thời gian đợi mỗi lần di chuyển
    public float waitTime;
    public bool isAttacking = false;
    public Animator anim;


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInParent<Animator>();
        this.waitTime = delayAttackTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(anim) anim.SetBool("isAttacking", isAttacking);
        if (isAttacking)
        {
            this.waitTime = this.waitTime - Time.deltaTime; // cập nhật thời gian đợi còn lại
            if (this.waitTime <= 0) 
            { 
                Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                player.SendMessage("Damage", damage); // gửi damage cho player
                this.waitTime = delayAttackTime; // cập nhật lại delayTime cho lần sau
                isAttacking = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isAttacking = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isAttacking = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isAttacking = false;
    }
}
