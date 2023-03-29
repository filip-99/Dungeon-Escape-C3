using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    int IDamageable.health { get; set; }

    public override void Init()
    {
        base.Init();
        health = base.health;
    }

    public override void Update()
    {
        // Potrebno je zakomentarisati lsedeću liniju koda, jer pauk neće sadržati neke promenjive u animatoru kao ostali neprijatelji. Pa će javljati grešku, kako određena promenjiva ne postoji
        // base.Update();
    }

    public void Damage()
    {
        if (isDead)
            return;
        Debug.Log("Pauk kill");
        health--;
        Debug.Log(health);
        if (health < 1)
        {
            Instantiate(diamondInstance, gameObject.transform.position, Quaternion.identity);
            Instantiate(diamondInstance, gameObject.transform.position, Quaternion.identity).GetComponent<Diamond>().gems = base.gems;
            isDead = true;
            myAnimator.SetTrigger("Death");
        }
    }

    public override void MoveEnemy()
    {

    }
}
