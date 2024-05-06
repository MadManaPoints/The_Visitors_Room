using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    GameManager gm;
    [SerializeField] TMP_Text dialogueBox; 
    bool firstDialogue;
    bool secondDialogue;
    bool talking;
    [TextArea(3, 10)]
    public string [] dialogue; 
    bool next;
    void Start(){
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update(){
        if(firstDialogue){
            if(gm.index != 2){
                dialogueBox.text = dialogue[gm.index]; 
                if(Input.GetMouseButtonDown(0)){
                    gm.index += 1;
                }
            } else {
                dialogueBox.text = "";
            }
        }

        if(secondDialogue){
            if(gm.index != 4){
                dialogueBox.text = dialogue[gm.index];
                if(Input.GetMouseButtonDown(0)){
                    gm.index += 1;
                }
            } else {
                dialogueBox.text = "";
            }
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            if(gm.visits == 2){
                secondDialogue = true;
            } else {
                firstDialogue = true;
            }
        }
    }
}
