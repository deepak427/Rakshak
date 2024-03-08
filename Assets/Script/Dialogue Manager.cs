using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public TMP_InputField userInput;
    public ApiCaller apiCaller;
    public string threadId;

    void Start(){
        threadId=null;
    }

    
    public void StartDialogue(){
        
        animator.SetBool("isOpen",true);
        nameText.text="CEO Dunity";
    }
    public void DisplayNextSentence(string a){
        if(Input.GetKeyDown(KeyCode.Backspace)){
            EndDialogue();
            return;
        }
        string sentence=a;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence){
        dialogueText.text="";
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text+=letter;
            yield return null;
        }
    }
    void EndDialogue(){
        animator.SetBool("isOpen",false);
    }
    public void TakeInput(){
        string input=userInput.text;
        Debug.Log("This is threadId"+threadId);
        apiCaller.ApiCall(input, threadId);
        userInput.text="";
    }
}
