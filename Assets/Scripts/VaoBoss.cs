using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaoBoss : MonoBehaviour
{
    [Header("VaoBossKichHoat")]
    public GameObject ThungCan;
    public GameObject BossIntro;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            ThungCan.SetActive(true);
            BossIntro.SetActive(true);
            Destroy(gameObject);
        }
    }
}
