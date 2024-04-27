using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    bool beginDialogue;
    bool talking;
    public ObjectDialogue dialogue;

    void Update(){
        if(beginDialogue){

            if(talking && Input.GetMouseButtonDown(0)){
                talking = false; 
            }

            if(!talking){
                TriggerDialogue();
                talking = true; 
            } 
        }
    }
    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            beginDialogue = true;
        }
    }
}
