using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    void Start(){

    }
    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue();
    }
}
