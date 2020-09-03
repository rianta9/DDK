using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundALL : MonoBehaviour
{
    [Header("Sound TaiNguyen")]
    public AudioSource audioSource;
    public float[] thoigian;
    public AudioClip[] DanhSach;
    int i = 0;
    float nextSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        thoigian = new float[DanhSach.Length];
        for(int j = 0; j < thoigian.Length; j++)
        {
            thoigian[j] = (float)(DanhSach[j].length);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 0)
        {
            PlaySound(i);
            Debug.Log(DanhSach[i].name);
        }else
          if (Time.time>= nextSound + thoigian[i - 1])
        {
            PlaySound(i);
        }
        
    }
    public void PlaySound(int clip)
    {
        if (clip > DanhSach.Length)
            return;
        nextSound = Time.time;
        audioSource.clip = DanhSach[clip];
        audioSource.PlayOneShot(DanhSach[clip], 0.8f);
        i++;
    }
}
