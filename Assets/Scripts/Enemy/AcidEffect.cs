using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    Player myPlayer;

    [SerializeField]
    private float moveSpeed = 3f;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myPlayer = FindObjectOfType<Player>();

        StartCoroutine(DestroyObject());
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            myPlayer.Damage();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
