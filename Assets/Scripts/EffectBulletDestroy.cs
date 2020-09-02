using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBulletDestroy : MonoBehaviour
{
    public bool isDestroy = false;
    // Start is called before the first frame update

    void Update()
    {
        if (isDestroy)
        {
            Destroy(gameObject);
        }
    }
    void DestroyTrue()
    {
        isDestroy = true;
    }
  
}
