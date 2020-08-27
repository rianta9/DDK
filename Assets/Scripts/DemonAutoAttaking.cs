using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Trong đối tượng demon, tạo 1 gameobject...add script này vào đó */
public class DemonAutoAttaking : MonoBehaviour
{
    public int damage = 5; // damge mỗi lần tấn công
    public float delayAttackTime = 0.5f; // thời gian sử dụng kỹ năng tấn công(lấy thời gian ở animation attack + 0.2(thời gian chênh lệch))
    public float delayWaitTime = 0.5f; // thời gian đợi sau mỗi lượt tấn công
    [SerializeField] private float waitTime; // đếm thời gian đợi
    [SerializeField] private float attackTime; // đếm thời gian tấn công
    public bool isAttacking = false;
    public Animator anim;


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInParent<Animator>();
        this.waitTime = 0;
        this.attackTime = delayAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            this.waitTime = this.waitTime - Time.deltaTime; // cập nhật thời gian đợi tấn công còn lại
            if (this.waitTime <= 0) // nếu hết thời gian đợi => đến lúc tấn công
            {
                if (anim) anim.SetBool("isAttacking", true); // set trạng thái tấn công
                attackTime -= Time.deltaTime; // cập nhập thời gian sử dụng kỹ năng tấn công
                if (attackTime <= 0)
                {
                    this.waitTime = delayWaitTime; // cập nhật lại delayTime cho lần sau
                    this.attackTime = delayAttackTime; // cập nhật lại attackTime cho lần sau

                    Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                    player.SendMessage("Damage", damage); // gửi damage cho player
                }
            }
            else if (anim) anim.SetBool("isAttacking", false);
        }
        else if (anim) anim.SetBool("isAttacking", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttacking = true;
            DemonMoveAround script = gameObject.GetComponentInParent<DemonMoveAround>();
            if (script)
            {
                script.isRunning = false;
                script.delayRunTime = int.MaxValue;
                script.anim.SetBool("isRunning", script.isRunning);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttacking = true;
            DemonMoveAround script = gameObject.GetComponentInParent<DemonMoveAround>();
            if (script)
            {
                script.isRunning = false;
                script.delayRunTime = int.MaxValue;
                script.anim.SetBool("isRunning", script.isRunning);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttacking = false;
            this.waitTime = 0;
            this.attackTime = delayAttackTime;
            DemonMoveAround script = gameObject.GetComponentInParent<DemonMoveAround>();
            if (script)
            {
                script.delayRunTime = 0.5f; // refresh delayRunTime
            }
        }
    }
}
