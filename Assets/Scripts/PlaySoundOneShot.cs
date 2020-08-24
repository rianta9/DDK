using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Nếu player di chuyển vào vùng được xác định thì play sound
 Sound được mở một lần duy nhất khi player tiến vào vùng này
---------------------------------Cách sử dụng
 Tạo một component box colider ở một object. set is trigger = true, set phạm vi box
 Add script Area vào object
 Tạo một component Audio Sound ở object
 Add script này vào object, set sound và volume cho script này.
 */

public class PlaySoundOneShot : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;
    public float volume = 0.1f;
    public Area areaPlaySound; // lấy phạm vi vùng được chỉ định

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        areaPlaySound = gameObject.GetComponent<Area>();
    }

    void Update()
    {
        if (areaPlaySound.isInRange)
        {
            areaPlaySound.isInRange = false;
            if (sound) audioSource.PlayOneShot(sound, volume); // phát âm thanh 
        }
    }
}
