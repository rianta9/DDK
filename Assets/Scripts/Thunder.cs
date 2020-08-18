using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Add script này vào thunder hoặc các đối tượng như thunder
 Mặc định mỗi một giây sẽ refresh trạng thái isFalling(đánh xuống) một lần, 
 dùng random để thay đổi trạng thái(<0.7 -> đánh xuống, > 0.7 -> không đánh xuống)
 Nếu người chơi rơi vào vùng sét đánh(isInRange) -> mặc định hạ 50 máu(damage)
 Class Player phải có 1 hàm void Damage(int blood) để trừ số máu bị hạ
 */

public class Thunder : MonoBehaviour
{
    private Animator anim;
    public float randomTime = 1f;
    public float waitTime = 1f;
    public int damage = 50;
    private float currentRandomTime;
    private float currentWaitTime;
    private bool isFalling = false;
    private bool isInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentRandomTime = randomTime;
        currentWaitTime = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Fall", isFalling);
        if (isFalling)
        {
            currentWaitTime -= Time.deltaTime;
            if (currentWaitTime <= 0)
            {
                if (isInRange)
                {
                    Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                    player.SendMessage("Damage", damage); // gửi damage cho player
                }
                isFalling = false;
                currentWaitTime = waitTime;
            }
        }
        else
        {
            currentRandomTime -= Time.deltaTime;
            if (currentRandomTime <= 0)
            {
                float rand = Random.Range(0f, 1f);
                if (rand <= 0.7f) isFalling = true;
                else isFalling = false;
                currentRandomTime = randomTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isInRange = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isInRange = false;
    }
}
