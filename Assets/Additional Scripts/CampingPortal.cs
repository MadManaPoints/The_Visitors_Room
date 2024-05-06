using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampingPortal : MonoBehaviour
{
    GameManager gm; 
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            gm.camping = true;
        }
    }
}
