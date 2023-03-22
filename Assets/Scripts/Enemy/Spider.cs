using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    int IDamageable.health { get; set; }

    public void Damage()
    {

    }

    public override void Init()
    {
        base.Init();
    }
}
