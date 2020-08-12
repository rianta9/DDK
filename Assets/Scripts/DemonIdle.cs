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
    public int damage = 20;
    public int wakeRange = 5; // nếu player nằm trong bán kính 5cm so với quái thì quái sẽ xuất hiện

    public float delayDieTime = 1f; // thời gian chờ animation death
    public float delayAttackTime = 0.2f;

    public int faceDirection = 1; // hướng nhìn ban đầu của demon. Nếu mặt demon hướng về bên trái thì set -1, ngược lại set 1

    public bool isAttaking = false;
    public bool isAwaking = false;

    public Animator anim;
    AutoControlDemon control;
    Player player = FindObjectOfType<Player>();

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

    void Update()
    {
        RangeCheck();
        anim.SetBool("Awake", isAwaking);

        // cập nhật hướng nhìn của demon
        Vector3 scale = transform.localScale;
        if (player.transform.position.x > this.transform.position.x) // nếu vị trí x của người chơi lớn hơn demon
        {
            scale.x = faceDirection*Mathf.Abs(scale.x); // mặt demon hướng về bên phải
        }
        else scale.x = -(Mathf.Abs(scale.x))*faceDirection; // mặt demon hướng về bên trái
        transform.localScale = scale; // cập nhật


        if (this.blood <= 0)
        {
            anim.SetBool("isDied", true);
            delayDieTime -= Time.deltaTime;
            if (delayDieTime <= 0)
            {
                Destroy(gameObject);
                control.SetDemonDied(true);
            }
        }

        else if (isAwaking && isAttaking)
        {
            delayAttackTime -= Time.deltaTime; // cập nhật thời gian đợi còn lại
            if (delayAttackTime <= 0) // nếu hết thời gian đợi thì cho phép tấn công
            { // nếu đến lúc tấn công
                anim.SetBool("isAttaking", isAttaking); // bật animation tấn công
                delayAttackTime = 0.2f; // cập nhật lại delayTime cho lần sau
                Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                player.SendMessageUpwards("Damage", damage); // gửi damage cho player
            }
        }
    }

    void RangeCheck()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= wakeRange) isAwaking = true;
        else isAwaking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isAttaking = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isAttaking = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isAttaking = false;
        }
    }
}
