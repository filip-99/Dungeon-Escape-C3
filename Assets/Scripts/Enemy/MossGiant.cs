using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    int IDamageable.health { get; set; }

    public override void Init()
    {
        base.Init();

        health = base.health;
    }

    public override void MoveEnemy()
    {
        base.MoveEnemy();
    }

    public void Damage()
    {
        health--;
        myAnimator.SetTrigger("Hit");
        isHit = true;
        myAnimator.SetBool("InCombat", true);
        if (health < 1)
        {
            isDead = true;
            myAnimator.SetTrigger("Death");
        }
    }
}
