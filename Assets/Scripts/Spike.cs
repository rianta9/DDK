using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Add script này vào đối tượng bẫy cấu rỉa máu
 Nếu player nằm trong phạm vi rỉa máu của đối tượng, mặc định refreshTime(giây) sẽ hạ máu player một lần
 Class Player phải có 1 hàm void Damage(int blood) để trừ số máu bị hạ
 */

public class Spike : MonoBehaviour
{
    public int damage = 5;
    public float refreshTime = 1f;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = refreshTime;
                Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                player.SendMessage("Damage", damage);
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            time = 0;
        }
    }
}
