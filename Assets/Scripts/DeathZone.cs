using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Script này dùng cho deathzone
 Người và vật thể chạm vào deathzone sẽ bị destroy
 */
public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D another)
    {
        if (another.CompareTag("Player"))
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.Death();
        }
        else Destroy(another.gameObject);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    //        player.Death();
    //    }
    //    else Destroy(collision.gameObject);
    //}
}
