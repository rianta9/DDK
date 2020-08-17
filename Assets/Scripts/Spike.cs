using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage = 5;
    public float refreshTime = 1f;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = refreshTime;
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
}
