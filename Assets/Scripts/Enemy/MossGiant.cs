using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MossGiant : Enemy
{
    SpriteRenderer mySpriteRenderer;
    Animator myAnimator;

    bool moveRight = true;

    void Start()
    {
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        myAnimator = GetComponentInChildren<Animator>();

        pointA.parent = null;
        pointB.parent = null;

        Attack();
    }

    public override void Update()
    {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Moss_Giant_Idle"))
            return;
        MoveMossGiant();
    }

    private void MoveMossGiant()
    {
        if (moveRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, moveSpeed * Time.deltaTime);
            if (transform.position.x >= pointB.position.x)
            {
                WaitAndMove(false);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, moveSpeed * Time.deltaTime);
            if (transform.position.x <= pointA.position.x)
            {
                WaitAndMove(true);
            }
        }

    }

    void WaitAndMove(bool isTrue)
    {
        myAnimator.SetTrigger("Idle");
        mySpriteRenderer.flipX = !isTrue;
        moveRight = isTrue;
    }
}
