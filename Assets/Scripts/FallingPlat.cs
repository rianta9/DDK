using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public Rigidbody2D r2;
    public float timedelay = 2;
    // Use this for initialization
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player")) // kiem tra nguoi chơi player có chạm với Rigi
        {
            StartCoroutine(fall());  // kích hoạt fuction
        }
    }

    IEnumerator fall()
    {
        yield return new WaitForSeconds(timedelay);
        r2.bodyType = RigidbodyType2D.Dynamic; // sau khi doi 2s thi chuyen static sang Dymamic
        yield return 0;
    }   
}
