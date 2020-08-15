using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{
    public Rigidbody2D r2;
    public float timeDelay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D another)
    {
        if (another.collider.CompareTag("Player"))
        {
            StartCoroutine(fall());
        }
    }

    IEnumerator fall()
    {
        yield return new WaitForSeconds(timeDelay);
        r2.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
}
