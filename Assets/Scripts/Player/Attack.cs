using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    bool wasAttacked;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // pomoću promenjive other, koja upravlja kolajderom koji udarimo uzimamo komponentu skripte, jer ona ima implementiran interfejs IDamageable sa svim metodama
        if (other.GetComponent<IDamageable>() != null && !wasAttacked)
        {
            wasAttacked = true;
            other.GetComponent<IDamageable>().Damage();
            StartCoroutine(RestartAttack());
        }
    }

    IEnumerator RestartAttack()
    {
        yield return new WaitForSeconds(.5f);
        wasAttacked = false;

    }
}
