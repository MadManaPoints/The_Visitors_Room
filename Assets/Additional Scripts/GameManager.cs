using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool camping;
    public bool exitCampsite; 
    public int bellPresses = 0;
    public bool lightsOut;
    public int visits = 1;
    public int flowers = 0;
    public int index = 0; 
    public bool holdingFlowers;
    public bool end;
    void Start()
    {
        
    }

    void Update()
    {
        LoadScenes();

        if(bellPresses >= 3){
            lightsOut = true;
            GameObject obj = GameObject.Find("Waiting Room Light");
            Destroy(obj);
        }
    }

    void LoadScenes(){
        if(camping){
            SceneManager.LoadScene("Camping");
            visits += 1;
            camping = false;
        }

        if(exitCampsite){
            SceneManager.LoadScene("The Visitors' Room (WIP)");
            bellPresses = 0;
            holdingFlowers = true;
            lightsOut = false;
            exitCampsite = false; 
        }
    }
}
