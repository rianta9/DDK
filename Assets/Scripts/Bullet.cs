using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 15;
	public Rigidbody2D rb;
	public GameObject impactEffect;
	public float timeDestroy = 0.5f;

	[Header("Sound Bullet")]
	public AudioSource audioBullet;
	public AudioClip soundbullet;
	// Use this for initialization
	void Start()
	{
		rb.velocity = transform.right * speed;
		timeDestroy += Time.time;
		audioBullet.clip = soundbullet;
		audioBullet.PlayOneShot(soundbullet,1f);

	}
    private void Update()
    {
		
		if (Time.time > timeDestroy)
        {
			
			Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
	{
		if (hitInfo.CompareTag("Enemy") || hitInfo.CompareTag("Boss"))
			hitInfo.SendMessageUpwards("TakeDamage", 10);
		else if (hitInfo.CompareTag("ThanhGo")) ;
		else return;
		
		//if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("NPC"))
  //      {

		//	return;
		//}
	
		Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
