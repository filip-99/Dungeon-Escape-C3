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
    protected int gems ;
    [SerializeField]
    protected GameObject diamondInstance;
    [SerializeField]
    protected Transform pointA, pointB;

    protected SpriteRenderer mySpriteRenderer;
    protected Animator myAnimator;

    protected bool moveRight = true;
    protected bool isHit;
    protected Player myPlayer;
    protected bool isDead = false;

    public virtual void Init()
    {
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        myAnimator = GetComponentInChildren<Animator>();
        // Pronalaženje objekta po tagu Player
        myPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
            if (!myAnimator.GetBool("InCombat")) // U koliko je "prekidač" za napad na kostura setovan na true
                return;
        if (!isDead)
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

        float distance = Vector3.Distance(transform.localPosition, myPlayer.transform.localPosition);
        if (distance > 2.0f)
        {
            isHit = false;
            myAnimator.SetBool("InCombat", false);
        }

        Vector3 direction = myPlayer.transform.localPosition - transform.localPosition;

        if (direction.x > Mathf.Epsilon && myAnimator.GetBool("InCombat"))
        {
            mySpriteRenderer.flipX = false;
        }
        else if (direction.x < Mathf.Epsilon && myAnimator.GetBool("InCombat"))
        {
            mySpriteRenderer.flipX = true;
        }

    }

    public virtual void WaitAndMove(bool isTrue)
    {
        myAnimator.SetTrigger("Idle");
        mySpriteRenderer.flipX = !isTrue;
        moveRight = isTrue;
    }
}
