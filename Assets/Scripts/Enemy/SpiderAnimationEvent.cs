using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    [SerializeField]
    GameObject acidEffect;
    GameObject instance;

    public void Fire()
    {
        instance = Instantiate(acidEffect);
        instance.transform.position = new Vector3(-48.7820015f, 1.78999996f, 0f);
    }
}
