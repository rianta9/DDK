using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBoss : MonoBehaviour
{
    bool End = false;
    public GameObject BossChinh;
    public GameObject HealthBarBoss;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (End)
        {
            BossChinh.SetActive(true);
            HealthBarBoss.SetActive(true);
            Destroy(gameObject);
        }
    }
    void isEnd()
    {
        End = true;
    }
}
