using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]

    protected Transform pointA, pointB;
    protected SpriteRenderer mySpriteRenderer;
    protected Animator myAnimator;

    protected bool moveRight = true;
    protected bool isHit;

    public virtual void Init()
    {
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        myAnimator = GetComponentInChildren<Animator>();
    }

    public void Start()
    {
        Init();
        pointA.parent = null;
        pointB.parent = null;
    }

    public virtual void Update()
    {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Skeleton_Idle") || myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Moss_Giant_Idle") || myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Spider_Idle"))
        {
            return;
        }
        MoveEnemy();
    }

    public virtual void MoveEnemy()
    {
        if (!isHit)
        {
            if (moveRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
                if (transform.position.x >= pointB.position.x)
                {
                    WaitAndMove(false);
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
                if (transform.position.x <= pointA.position.x)
                {
                    WaitAndMove(true);
                }
            }

        }

    }

    public virtual void WaitAndMove(bool isTrue)
    {
        myAnimator.SetTrigger("Idle");
        mySpriteRenderer.flipX = !isTrue;
        moveRight = isTrue;
    }
}