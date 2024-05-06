using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool doorOpen;
    Vector3 open; 
    void Start()
    {
        open = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y - 90f, transform.localEulerAngles.z);
    }

    void Update()
    {
        if(doorOpen){
            this.transform.localEulerAngles = open;
        }
    }
}
