using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [Header("Boss")]
    public int MaxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject healthBarboss;
    public DoorDichChuyen doorQuaCua;
    public GameObject ThungCan;

    //lookatplayer
    public Transform player;
    public bool isFlipped = false;

    public bool isBienHinh = false;
    public NPC_DoiThoai HoanThanhNPC;

    [Header("BossChat")]
    public Text BossText;
    public string NoiDungTranTroi;
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
        GetComponent<Animator>().SetBool("IsDie", true);
        StartCoroutine(XoaHealthBarBoss(2.2f));
        healthBar.enabled = false;
        BossText.text = NoiDungTranTroi;
        
    }
    void TakeDamage(int damage)
    {
        if (isBienHinh)
            return;
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);

        if (currentHealth <= 0)
            Death();
        else if(currentHealth <= MaxHealth*0.3f)
        {
            GetComponent<Animator>().SetBool("IsEnraged",true);
        }
    }
    IEnumerator XoaHealthBarBoss(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        healthBarboss.SetActive(false);
        doorQuaCua.OpenDoor(true);
        HoanThanhNPC.IsBossDie = true;
        BossText.text = "";
        Destroy(ThungCan.gameObject);
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
    public void BuffHP(int HP_up)
    {
        currentHealth += HP_up;
        healthBar.setHealth(currentHealth);
    }
}

