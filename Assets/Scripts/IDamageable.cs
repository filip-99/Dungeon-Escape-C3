using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    int health { get; set; }
    void Damage();
}
