using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public GameObject reply;
    public GameObject startDialog; 
    public GameObject puzzleWindow;
    public GameObject instruction;
    public void Nextpara(){
        SceneManager.LoadScene("Intro 2");
    }
    public void PlayGame(){
        SceneManager.LoadScene("New Scene");
    }
    public void StartPuzzle(){
        puzzleWindow.SetActive(true);
        startDialog.SetActive(false);
        reply.SetActive(false);
    }
    public void ClosePuzzle(){
        puzzleWindow.SetActive(false);
        startDialog.SetActive(true);
        reply.SetActive(true);
    }
    public void Instrctions(){
        instruction.SetActive(true);
    }
    public void CloseInstrctions(){
        instruction.SetActive(false);
    }
}
