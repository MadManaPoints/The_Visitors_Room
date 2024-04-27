using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskBell : MonoBehaviour
{
    FirstPersonLook player;
    Vector3 initialPos;
    Vector3 newPos; 
    bool press;
    [SerializeField] GameObject ding;

    void Start()
    {
        player = GameObject.Find("First Person Camera").GetComponent<FirstPersonLook>();
        initialPos = ding.transform.position;
        newPos = new Vector3(ding.transform.position.x, ding.transform.position.y - 0.005f, ding.transform.position.z);
    }

    void Update()
    {
        if(player.rungBell){
            ding.transform.position = newPos; 
            //Debug.Log("YERR");
        } else {
            ding.transform.position = initialPos; 
        }
    }
}
