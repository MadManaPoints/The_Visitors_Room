using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCamp : MonoBehaviour
{
    GameManager gm;
    FirstPersonLook player;
    [SerializeField] GameObject door;
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        player = GameObject.Find("First Person Camera").GetComponent<FirstPersonLook>();
        door.SetActive(false);
    }

    void Update()
    {
        if(player.bouquet){
            door.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            gm.exitCampsite = true;
        }
    }
}
