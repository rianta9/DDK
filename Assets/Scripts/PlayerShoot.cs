using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
	public float nextTimeShoot = 0.5f;
	public Animator animator;
	public PlayerComBat playerComBat;
	public Player playerBasic;
	float TimeShootDelay;
    // Update is called once per frame
    private void Start()
    {
		TimeShootDelay = Time.time;
		playerComBat = gameObject.GetComponent<PlayerComBat>();
		animator = gameObject.GetComponent<Animator>();
		playerBasic = gameObject.GetComponent<Player>();
	}
    void Update()
	{
        if(Time.time >= TimeShootDelay)
        {
			if (Input.GetKeyDown(KeyCode.C) && !playerComBat.attacking && playerBasic.currentHealth > 0)
			{
				Shoot();
				TimeShootDelay = Time.time + nextTimeShoot;
			}
		}
	}

	void Shoot()
	{
		animator.Play("Player_shoot");
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
