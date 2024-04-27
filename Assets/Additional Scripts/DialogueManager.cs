using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    //FIFO - First In, First Out
    Queue<string> sentences; 
    void Start()
    {
        sentences = new Queue<string>();
    }
   
    public void StartDialogue(ObjectDialogue dialogue){
        //Debug.Log("Starting convo"); 
        //NOT WORKING AS IT SHOULD YET
        //sentences.Clear();

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        } 
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence; 
    }

    void EndDialogue(){
        dialogueText.text = ""; 
    }
}
