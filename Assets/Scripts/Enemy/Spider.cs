using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDemagable
{
    public GameObject accidEffectPrefab;
    public int Health { get; set; }

    public void Damage()
    {
        Debug.Log("Damage Spider");
        Health--;
        if(Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
        }
    }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Update()
    {
        
    }

    public override void Movment()
    {
        //sit down
    }

    public void Attack()
    {
        Instantiate(accidEffectPrefab, transform.position, Quaternion.identity);
    }
}
