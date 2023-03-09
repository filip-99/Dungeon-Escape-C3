using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Biće kreirana funkcionalnost za mobile i pc

    Rigidbody2D myRigidBody;
    BoxCollider2D myCollider;
    SpriteRenderer mySpriteRenderer;
    Animator myAnimator;
    // Potrebna referenca animacije za efekat sečenja 
    Animator mySwordAnimation;
    SpriteRenderer mySwordSpriteRender;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 2f;

    Vector2 moveInput;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        myAnimator = GetComponentInChildren<Animator>();
        // Na ovaj naćin dolazimo direkt do podobjekta i referenciramo na njegovu komponentu animator
        mySwordAnimation = transform.GetChild(1).GetComponent<Animator>();
        mySwordSpriteRender = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Run();
        FlipSprite();
        myAnimator.SetBool("Jumping", !myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")));
    }

    void OnJump(InputValue value)
    {

        // hitInfo biće !=null u koliko se od pozicije ispod igrača za 1f nalazi neki objekat
        // RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 5.0f);
        // 
        // if (hitInfo.collider != null)
        // {
        //     Debug.Log("Hit: " + hitInfo.collider.name);
        // }

        if (value.isPressed && myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        }
    }

    void OnMove(InputValue value)
    {

        // myRigidBody.velocity = new Vector2(value.Get<Vector2>() * moveSpeed, myRigidBody.velocity.y);
        moveInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {

        if (value.isPressed && myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myAnimator.SetTrigger("Attack");
            mySwordAnimation.SetTrigger("SwordAnimation");
        }
    }

    void Run()
    {
        myRigidBody.velocity = new Vector2(moveInput.x * moveSpeed, myRigidBody.velocity.y);
        myAnimator.SetFloat("Move", Mathf.Abs(myRigidBody.velocity.x));

    }

    private void FlipSprite()
    {
        bool playerHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHorizontalSpeed)
        {
            if (Mathf.Sign(myRigidBody.velocity.x) == 1)
            {
                mySpriteRenderer.flipX = false;

                mySwordSpriteRender.transform.localPosition = new Vector3(1.01f, mySwordSpriteRender.transform.localPosition.y, mySwordSpriteRender.transform.localPosition.z);
                mySwordSpriteRender.flipX = false;
                mySwordSpriteRender.flipY = false;
            }
            else if (Mathf.Sign(myRigidBody.velocity.x) == -1)
            {
                mySpriteRenderer.flipX = true;

                mySwordSpriteRender.transform.localPosition = new Vector3(-1.01f, mySwordSpriteRender.transform.localPosition.y, mySwordSpriteRender.transform.localPosition.z);
                mySwordSpriteRender.flipX = true;
                mySwordSpriteRender.flipY = true;
            }
        }
    }
}
