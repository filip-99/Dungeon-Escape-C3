using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    // Instance predstavlja property, kog koristimo za pristup privatnom polju instance
    public static GameManager Instance
    {
        get
        {
            // Vrši se provera da li je kreirana instanca koja referencira na klasu GameManager
            if (instance == null)
                Debug.Log("GameManager is null");
            return instance;
        }
    }

    public bool HasKeyToCastle { get; set; }

    public Player Player { get; set; }

    private void Awake()
    {
        instance = this;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}
