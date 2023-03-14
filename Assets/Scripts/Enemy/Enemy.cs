using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int health;
    protected int speed;
    protected int gems;

    public virtual void Attack()
    {
        Debug.Log("Ime objekta je: " + this.gameObject.name);
    }
}
