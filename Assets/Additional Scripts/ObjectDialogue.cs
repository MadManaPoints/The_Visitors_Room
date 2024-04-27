using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class ObjectDialogue
{
    //text are box
    //min and max to provide more space in inspector 
    [TextArea(3, 10)]
    public string [] sentences; 
}
