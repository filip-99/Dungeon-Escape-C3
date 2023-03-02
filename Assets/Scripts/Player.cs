using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Biće kreirana funkcionalnost za mobile i pc

    Rigidbody2D myRigidBody;
    BoxCollider2D myCollider;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 2f;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // GetAxisRaw() utiče na to da igrač ne klizi, dakle kad se pusti dugme setuje brzinu na 0 odmah
        myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidBody.velocity.y);

    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Dodiruje");
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
        }
    }

    void OnMove(InputValue value)
    {

        // myRigidBody.velocity = new Vector2(value.Get<Vector2>() * moveSpeed, myRigidBody.velocity.y);
    }
}
