using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip swords, thunder, waterfall;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        swords = Resources.Load<AudioClip>("swords"); // tên phải trùng với tên file
        thunder = Resources.Load<AudioClip>("thunder");
        waterfall = Resources.Load<AudioClip>("waterfall");
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string audioName)
    {
        switch(audioName)
        {
            case "swords audio":
                audioSource.clip = swords;
                audioSource.PlayOneShot(swords, 0.6f);
                break;
            case "thunder audio":
                audioSource.clip = swords;
                audioSource.PlayOneShot(swords, 0.6f);
                break;
            case "waterfall audio":
                audioSource.clip = waterfall;
                audioSource.PlayOneShot(waterfall, 0.6f);
                break;
        }
    }
}
