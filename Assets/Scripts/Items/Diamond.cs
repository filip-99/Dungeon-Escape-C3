using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int gems = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetComponent<Player>() != null)
        {
            other.GetComponent<Player>().AddGems(gems);
            Destroy(gameObject);
        }
    }
}
