﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D r2;
    public Transform tran_player;

    public int MaxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;


    void Start()
    {
        currentHealth = MaxHealth;
        healthBar.setMaxHealth(MaxHealth);
        r2 = gameObject.GetComponent<Rigidbody2D>();
        tran_player = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamage(10);
        }
    }

    public void Death()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        Knockback(100, tran_player.rotation.y);
        if (currentHealth <= 0)
            Death();
    }
    public void Knockback(int pow, float huong)
    {
        r2.AddForce(Vector2.up * pow);
        //if (huong  == 180)
        //{
        //    r2.AddForce(Vector2.up * pow);
        //    r2.AddForce(Vector2.right * pow);
        //}
        //else
        //{
        //    r2.AddForce(Vector2.up * pow);
        //    r2.AddForce(Vector2.left * pow);
        //}

    }
}
