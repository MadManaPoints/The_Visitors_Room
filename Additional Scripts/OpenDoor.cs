using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    bool doorOpen; 
    void Start()
    {
        
    }

    void Update()
    {
        if(!doorOpen && Input.GetMouseButtonDown(0)){
            doorOpen = true;
        }

        if(doorOpen){
            this.transform.localEulerAngles = new Vector3(0, -90, 0);
        }
    }
}
