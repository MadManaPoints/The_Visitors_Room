using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColor : MonoBehaviour
{
    GameManager gm;
    [SerializeField] GameObject door;
    [SerializeField] Material doorColor;
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(gm.visits == 3){
            door.GetComponent<Renderer>().material = doorColor; 
        }
    }
}
