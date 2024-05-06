using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    ObjectDialogue dialogue; 
    public TextMeshProUGUI dialogueText;
    //FIFO - First In, First Out
    string [] sentenceQueue;
    bool next;
    bool oneShot; 
    int index; 
    void Start()
    {
      
    }
}