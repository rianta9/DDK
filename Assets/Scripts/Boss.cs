using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject healthBarboss;


    //lookatplayer
    public Transform player;
    public bool isFlipped = false;

    // Start is called before the first frame update
    void Start()
    {


        currentHealth = MaxHealth;
        healthBar.setMaxHealth(MaxHealth);
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           
            TakeDamage(10);
        }
    }
    public void Death()
    {
        StartCoroutine(XoaHealthBarBoss(1.2f));
        healthBar.enabled = false;
        
        
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);

        if (currentHealth <= 0)
            Death();
    }
    IEnumerator XoaHealthBarBoss(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        healthBarboss.SetActive(false);
        Destroy(gameObject);
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }
    }
}
