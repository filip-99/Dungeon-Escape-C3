using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Potrebno je importovati sledeću biblioteku, za ubacivanje reklama
using UnityEngine.Advertisements;
using static Unity.Burst.Intrinsics.Arm;

public class AdsManager : MonoBehaviour
{
    // Metoda prikazuje oglas u igri za dijamante
    public void ShowRewardedAd()
    {
        Debug.Log("Prikaži oglas");

        // Dakle, ovaj uslov proverava da li aplikacija trenutno ima spremnu "rewarded video" reklamu,
        // kako bi se mogla prikazati kada igrač uđe u šop.
        // Ako je uslov tačan, kod nastavlja sa prikazivanjem reklame,
        // a ako nije, verovatno se nastavlja sa izvršavanjem drugih funkcija u aplikaciji.
        if (Advertisement.IsReady("rewardedVideo"))
        {
            // Ako je reklama spremna, tada se koristi ShowOptions klasa
            var options = new ShowOptions
            {
                // Funkcija "HandleShowResult" koja se dodeljuje opciji "resultCallback" definiše ponašanje koje će se dogoditi nakon prikazivanja reklame, 
                // JER Opcija "resultCallback" omogućava da se nakon prikazivanja reklame obavi neka akcija
                resultCallback = HandleShowResult
            };

            Advertisement.Show("rewardedVideo", options);
        }

        // Funkcija koja obrađuje rezultat prikaza reklame i vrši različite radnje na osnovu toga da li je reklama uspešno prikazana, preskočena ili se dogodila greška.
        void HandleShowResult(ShowResult result)
        {
            switch (result)
            {
                // "ShowResult.Finished", to znači da je reklama uspešno prikazana do kraja i da igraču treba dodeliti 100 dragulja za odgledanu reklamu
                case ShowResult.Finished:
                    break;
                // "ShowResult.Skipped", to znači da je korisnik preskočio reklamu, i u ovom slučaju se obično ne preduzima nikakva posebna akcija
                case ShowResult.Skipped:
                    break;
                // "ShowResult.Failed", to znači da je došlo do neke greške pri prikazivanju reklame
                case ShowResult.Failed:
                    break;
            }
        }
    }
}
