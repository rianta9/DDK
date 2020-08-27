﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D r2;
    public Transform tran_player;

    public int MaxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public bool isKockBack;

    void Start()
    {
        currentHealth = MaxHealth;
        healthBar.setMaxHealth(MaxHealth);
        r2 = gameObject.GetComponent<Rigidbody2D>();

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
        //if (gameOverSound) audioSource.PlayOneShot(gameOverSound, 0.8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
       
        if (currentHealth <= 0)
            Death();
    }
    public void Knockback(Vector2 PowHuong)
    {
        //x pow ,y = huong;
        isKockBack = true;
        if (PowHuong.y < 0)
        {
            r2.AddForce(Vector2.up * PowHuong.x * 1.25f);
            r2.AddForce(Vector2.right * PowHuong.x * 1.5f);
        }
        else
        {
            r2.AddForce(Vector2.up * PowHuong.x * 1.25f);
            r2.AddForce(Vector2.left * PowHuong.x * 1.5f);
        }

    }

    
}
