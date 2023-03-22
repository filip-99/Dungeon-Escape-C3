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
    }

    void IDamageable.Damage()
    {
        
    }
}
