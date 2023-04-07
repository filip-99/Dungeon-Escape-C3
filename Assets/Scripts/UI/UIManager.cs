using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Potrebno je kreirati singlton ove klase, za lakši pristup iz drugih skripti
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            // U koliko instanca nije inicijalizovana ispisaće grešku u konzoli
            if (instance == null)
                Debug.Log("UI Manager is Null!");
            return instance;
        }
    }

    public TextMeshProUGUI playerGemCountText;
    public Image selectionImg;
    public TextMeshProUGUI gemCountText;

    [SerializeField] Image[] healthSprite;

    private void Awake()
    {
        // Promenjivoj instance dodeljujemo referencu na ovu skriptu i time obezbeđujemo samo jednu referencu na klasu
        instance = this;

        // Ovaj kod će postaviti vidljivost igračkog objekta na true ako se aplikacija pokreće na mobilnoj platformi, a na false u suprotnom slučaju.
        // gameObject.SetActive(Application.isMobilePlatform);
    }

    // Potrebna je metoda koja će ažurirati podatke, kada se pojavi panel za šop
    public void OpenShop(int gemCount)
    {
        // Pošto je skripta menadžer, ona je samo posrednik i pomoću nje komuniciraju, pa se zato dostavljaju podaci metodama
        playerGemCountText.text = "" + gemCount + "G";
    }

    // Potrebno je da apdejtujemo sliku koja predstavlja select za dugme
    public void UpdateShopSelection(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int count)
    {
        gemCountText.text = "" + count;
    }

    public void UpdateLives(int health)
    {
        switch (health)
        {
            case 3:
                healthSprite[3].gameObject.SetActive(false);
                break;
            case 2:
                healthSprite[2].gameObject.SetActive(false);
                break;
            case 1:
                healthSprite[1].gameObject.SetActive(false);
                break;
            case 0:
                healthSprite[0].gameObject.SetActive(false);
                break;
        }
    }
}
