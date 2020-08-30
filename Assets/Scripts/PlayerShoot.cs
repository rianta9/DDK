using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
	public float nextTimeShoot = 0.5f;
	float TimeShootDelay;
    // Update is called once per frame
    private void Start()
    {
		TimeShootDelay = Time.time;

	}
    void Update()
	{
        if(Time.time >= TimeShootDelay)
        {
			if (Input.GetKeyDown(KeyCode.C))
			{
				Shoot();
				TimeShootDelay = Time.time + nextTimeShoot;
			}
		}
	}

	void Shoot()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
