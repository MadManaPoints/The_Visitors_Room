using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinFan : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * 5000.0f * Time.deltaTime);
    }
}
