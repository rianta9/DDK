using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public int enragedAttackDamage = 20;

    public Vector3 attackoffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackoffset.x;
        pos += transform.up * attackoffset.y;

        Collider2D collider = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if(collider != null)
        {
            collider.SendMessageUpwards("TakeDamage", attackDamage);
        }
    }
}
