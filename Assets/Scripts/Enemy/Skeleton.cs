using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    int IDamageable.health { get; set; }

    public override void Init()
    {
        base.Init();
        // Dakle na samom početku dodeljujemo helte skeletonu. Imaće onoliko helta koliko je dodeljeno u inspektoru
        health = base.health;
    }

    public void Damage()
    {
        health--;
        myAnimator.SetTrigger("Hit");
        isHit = true;
        myAnimator.SetBool("InCombat", true);
        if (health < 1)
        {
            Destroy(this.gameObject);
        }
    }

    public override void MoveEnemy()
    {
        base.MoveEnemy();
        float distance = Vector3.Distance(transform.localPosition, myPlayer.transform.localPosition);
        Debug.Log(distance);
    }

}