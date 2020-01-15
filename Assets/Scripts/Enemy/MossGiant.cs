using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDemagable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();

        Health = base.health;

    }

    public override void Movment()
    {
        base.Movment();
    }

    public void Damage()
    { 

        Health--;

        anim.SetTrigger("Hit");
        isHit = true;

        anim.SetBool("InCombat", true);


        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
        }
    }





}

