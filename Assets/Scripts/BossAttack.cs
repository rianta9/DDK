using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public int enragedAttackDamage = 20;

    public Transform Point_Attack;
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
        //Vector3 pos = transform.position;
        //pos += transform.right * attackoffset.x;
        //pos += transform.up * attackoffset.y;
        //Collider2D collider = Physics2D.OverlapCircle(pos, attackRange, attackMask);

        Collider2D collider = Physics2D.OverlapCircle(Point_Attack.position, attackRange, attackMask);
        if(collider != null)
        {
            collider.SendMessageUpwards("TakeDamage", attackDamage);
        }
    }
    public void EnrageAttack()
    {
        //Vector3 pos = transform.position;
        //pos += transform.right * attackoffset.x;
        //pos += transform.up * attackoffset.y;
        //Collider2D collider = Physics2D.OverlapCircle(pos, attackRange, attackMask);

        Collider2D collider = Physics2D.OverlapCircle(Point_Attack.position, attackRange, attackMask);
        if (collider != null)
        {
            collider.SendMessageUpwards("TakeDamage", enragedAttackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Point_Attack.position, attackRange);

        //Gizmos.DrawFrustum(Point_Attack.position, 20,10,2,0.5f);
    }
}
