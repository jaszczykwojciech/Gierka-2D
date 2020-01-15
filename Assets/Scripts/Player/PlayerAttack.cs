using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private PlayerAnimation anim;
    private float timeBeetweenAttack;
    public float startTimeBeetweenAttack;
    public Transform attackPos;
    public float attackRange = 0.5f;
    public LayerMask whatIsEnemy;
    public int damage= 1;
    // Start is called before the first frame upd   ate

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);
    }

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<PlayerAnimation>();
        
            if(Input.GetMouseButtonDown(0) == true)
            {
                anim.Attack();
                Collider2D[] enemiesToDamge = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                //for (int i = 0; i < enemiesToDamge.Length; i++)
                //{
                //    enemiesToDamge[i].GetComponent<Enemy>().TakeDamage(damage);
                //}
                foreach (Collider2D enemy in enemiesToDamge)
                {
                    
                    enemy.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                }
            }
    }
}
