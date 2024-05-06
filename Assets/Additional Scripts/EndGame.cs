using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    GameManager gm;
    [SerializeField] Image fade;
    [SerializeField] GameObject text;
    Color white;
    bool startFade;
    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        white = fade.color;
        text.SetActive(false);
    }

    void Update()
    {
        startFade = gm.end;
        //Debug.Log(white.a);
        if(startFade){
            fade.color = white;
            if(white.a < 1.0f){
                white.a += 0.5f * Time.deltaTime; 
            } else {
                white.a = 1.0f;
                text.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
