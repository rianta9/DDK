using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGateThunder : MonoBehaviour
{
    public float waitTime = 1f;
    private float currentWaitTime;
    public int damage = 50;

    public AudioSource audioSource;
    public AudioClip thunder;
    public Area thunderArea; // lấy phạm vi vùng sấm, dùng để phát tiếng sấm
    Player player;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //thunderArea = GameObject.FindObjectOfType<ThunderArea>();
        thunderArea = gameObject.GetComponentInParent<Area>();
        currentWaitTime = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (thunderArea.isInRange && !audioSource.isPlaying)
        {
            if (thunder) audioSource.PlayOneShot(thunder, 0.1f); // âm thanh sấm
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) player.SendMessage("Damage", damage); // gửi damage cho player
    }
}
