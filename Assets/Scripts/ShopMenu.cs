using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    [SerializeField]
    GameObject shopPanel;
    public int currentSelectedItem;
    public int currentItemCost;

    Player player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            if (player != null)
            {
                UIManager.Instance.OpenShop(player.diamond);
            }

            shopPanel.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(85);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-25);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-135);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;

        }
    }

    public void BuyItem()
    {
        if (player.diamond >= currentItemCost)
        {
            // Potrebno je da proverimo da li je odabran ključ tj. stavka 2. Fora je što je ključ uslov za pobedu
            if (currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            player.diamond -= currentItemCost;
            Debug.Log("Kupili ste ajtem: " + currentSelectedItem);
            Debug.Log("Trenutan broj dijamanata: " + player.diamond);
            shopPanel.SetActive(false);
        }
        else
        {
            Debug.Log("Nemate dovoljno dijaanata za ovaj ajtem");
            shopPanel.SetActive(false);
        }
    }
}
