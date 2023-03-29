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
        if (isDead)
            return;
        health--;
        myAnimator.SetTrigger("Hit");
        isHit = true;
        myAnimator.SetBool("InCombat", true);
        if (health < 1)
        {
            Instantiate(diamondInstance, gameObject.transform.position, Quaternion.identity);
            Instantiate(diamondInstance, gameObject.transform.position, Quaternion.identity).GetComponent<Diamond>().gems = base.gems;
            isDead = true;
            myAnimator.SetTrigger("Death");
        }
    }
}
