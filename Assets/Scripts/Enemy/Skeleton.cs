using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDemagable
{
    public int Health { get; set; }
    public override void Init()
    {
        base.Init();

        //assign health value to our enemy health
        Health = base.health;
    }

    public override void Movment()
    {
        base.Movment();
    }

    public void Damage()
    {
        Debug.Log("Skelton::Damage()");
     
        Health--;

        anim.SetTrigger("Hit");
        isHit = true;

        anim.SetBool("InCombat", true);
        
        
        if(Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
        }
    }


}
