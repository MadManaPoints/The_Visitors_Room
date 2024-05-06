using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepFlowers : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
