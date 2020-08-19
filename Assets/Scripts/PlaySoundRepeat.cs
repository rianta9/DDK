using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Nếu người chơi di chuyển vào vùng được xác định thì mở sound
 Sound được mở lặp đi lặp lại
------------------------------ Cách sử dụng
 Tạo một component box colider ở một object. set is trigger = true, set phạm vi box
 Add script Area vào object
 Tạo một component Audio Sound ở object
 Add script này vào object, set sound và volume cho script này.
 */

public class PlaySoundRepeat : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sound;
    public float volume = 0.3f;
    public Area areaPlaySound; // lấy phạm vi vùng được chỉ định

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        areaPlaySound = gameObject.GetComponent<Area>();
    }

    void Update()
    {
        if (areaPlaySound.isInRange && !audioSource.isPlaying)
        {
            if (sound) audioSource.PlayOneShot(sound, volume); // phát âm thanh
        }
    }
}
