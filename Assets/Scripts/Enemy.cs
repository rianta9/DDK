using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;

    [Header("Enemy Chat")]
    public Text TextDoiThoai;
    public string NoiDungTanGau;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

   
    public void TakeDamage(int damage)
    {
        gameObject.GetComponent<Animation>().Play("Trau_redflash");
        currentHealth -= damage;
        if (currentHealth <= 0)
            animator.SetBool("Die", true);
    }
    void Die()
    {
        
        GetComponent<Collider2D>().enabled = false;
    }
    void Died()
    {
        
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        ///GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        this.enabled = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            TextDoiThoai.text = NoiDungTanGau;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            TextDoiThoai.text = "";
        }

    }
    
}
