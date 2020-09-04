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
    public bool isNext = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (isNext)
        {
            thoigian = new float[DanhSach.Length];
            for (int j = 0; j < DanhSach.Length; j++)
            {
                thoigian[j] = (float)(DanhSach[j].length);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isNext)
        {
            if (i == 0)
            {
                PlaySound(i);
                i++;
            }
            else
          if (Time.time >= nextSound + thoigian[i - 1])
            {
                PlaySound(i);
                i++;
            }
        }
        
    }
    public void PlaySound(int clip,float amluong = 0.8f)
    {
        if (clip >= DanhSach.Length)
            return;
        nextSound = Time.time;
        audioSource.clip = DanhSach[clip];
        audioSource.PlayOneShot(DanhSach[clip], amluong);
        
    }
}
