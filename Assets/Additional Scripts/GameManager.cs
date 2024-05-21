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
    [SerializeField] Material white;
    void Start()
    {
        
    }

    void Update()
    {
        LoadScenes();

        if(bellPresses >= 3){
            lightsOut = true;
            GameObject obj = GameObject.Find("Waiting Room Light");
            obj.GetComponent<Light>().color = Color.black;
            obj.GetComponent<Renderer>().material = white;
        }
    }

    void LoadScenes(){
        if(camping){
            bellPresses = 0;
            SceneManager.LoadScene("Camping");
            visits += 2;
            camping = false;
        }

        if(exitCampsite){
            SceneManager.LoadScene("The Visitors' Room (WIP)");
            holdingFlowers = true;
            lightsOut = false;
            exitCampsite = false; 
        }
    }
}
