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
    public Animator animator;


    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponentInParent<Animator>();
        this.waitTime = delayAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isAttacking", isAttacking); // bật animation di chuyển
        if (isAttacking)
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
