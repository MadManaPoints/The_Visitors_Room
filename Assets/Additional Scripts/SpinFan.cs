using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinFan : MonoBehaviour
{
    FirstPersonLook player;
    float fanSpeed = 2000f;
    bool slowDown;
    float fakeVel = 40f;
    float fakeAcc = 0.02f;
    bool fakeStop;
    [SerializeField] GameObject blades;
    void Start()
    {
        player = GameObject.Find("First Person Camera").GetComponent<FirstPersonLook>();
    }

    void Update()
    {
        blades.transform.Rotate(Vector3.forward * fanSpeed * Time.deltaTime);

        if(player.fan){
            slowDown = false;
            fakeVel = 40;
            fakeAcc = 0.02f;
            fakeStop = false;
            fanSpeed = 2000.0f; 
        } else {
            slowDown = true; 
        }
        
        if(slowDown && fanSpeed > 0){
            fanSpeed -= fakeVel;
            fakeVel -= fakeAcc;
            if(fanSpeed < 1000.0f && !fakeStop){
                fakeVel = 10.0f;
                fakeAcc = 0.05f; 
                fakeStop = true;
            }

        }

        if(fanSpeed <= 0 && !player.fan){
            fanSpeed = 0;
            slowDown = false; 
        }

        //Debug.Log(fanSpeed);
        
    }
}
