using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Biće kreirana funkcionalnost za mobile i pc

    Rigidbody2D myRigidBody;

    [SerializeField] float moveSpeed = 5f;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // GetAxisRaw() utiče na to da igrač ne klizi, dakle kad se pusti dugme setuje brzinu na 0 odmah
        myRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidBody.velocity.y);
    }
}
