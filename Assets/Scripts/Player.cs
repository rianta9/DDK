using System;
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

    public SpriteRenderer playerSprite;
    public float TimeTakeDamage = .4f;
    public bool IsKey = false;

    bool isTakeDamage = false,isSpriteActive = true;

    [Header("SoundKey")]
    public PlayerSoundControl playerSoundControl;
    void Start()
    {
        currentHealth = MaxHealth;
        healthBar.setMaxHealth(MaxHealth);
        r2 = gameObject.GetComponent<Rigidbody2D>();
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamage(10);
        }
        if (isTakeDamage)
        {
            isSpriteActive = !isSpriteActive;
            if (isSpriteActive)
            {
                playerSprite.color = Color.white;
            }
            else
            {
                playerSprite.color = Color.red;
            }
            //playerSprite.enabled = isSpriteActive;
        }
    }

    public void Death()
    {
        //if (gameOverSound) audioSource.PlayOneShot(gameOverSound, 0.8f);
        GetComponent<Animator>().SetBool("IsDie", true);
        StartCoroutine(WaitDie(1.5f));
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        
        if (currentHealth <= 0)
            Death();
        else
        {
            isTakeDamage = true;
            StartCoroutine(WhiteFlash(TimeTakeDamage));
        }
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

    IEnumerator WhiteFlash(float time)
    {
        yield return new WaitForSeconds(time);
        isTakeDamage = false;
        isSpriteActive = true;
        playerSprite.color = Color.white;
        //playerSprite.enabled = true;
    }
    IEnumerator WaitDie(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                collision.SendMessageUpwards("DichChuyen");
            }
        }
        if (collision.CompareTag("NPC"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                collision.SendMessageUpwards("DoiThoai");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ChiaKhoa"))
        {
            collision.SendMessageUpwards("ChiaKhoaOn");
            IsKey = true;
            playerSoundControl.soundKey();
        }
    }
}
