using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;
    [SerializeField]
    protected float moveSpeed;


    public virtual void Attack()
    {
        Debug.Log("Ime objekta je: " + this.gameObject.name);
    }

    public abstract void Update();
}
