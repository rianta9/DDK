using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBulletDestroy : MonoBehaviour
{
    public bool isDestroy = false;
    public AudioSource audioeffect;
    // Start is called before the first frame update
    private void Start()
    {
        audioeffect.volume = 0.5f;
        audioeffect.Play();
    }
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
