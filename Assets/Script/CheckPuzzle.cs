using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CheckPuzzle : MonoBehaviour
{
    public TMP_Text answerField;
    public List<int> answer;
    void Start(){
        answer.Add(0);
    }

    public void add5()
    {
        int newValue=answer[answer.Count-1]+5;
        if(newValue>=60){
            return;
        }
        else if(answer.Contains(newValue)){
            return;
        }
        answer.Add(newValue);
        Display();
    }
    public void add7()
    {
        int newValue=answer[answer.Count-1]+7;
        if(newValue>=60){
            return;
        }
        else if(answer.Contains(newValue)){
            return;
        }
        answer.Add(newValue);
        Display();
    }
    public void sqrt()
    {
        int newValue=(int)Mathf.Sqrt(answer[answer.Count-1]);
        if(!IsPerfectSquare(answer[answer.Count-1])){
            return;
        }
        else if(answer.Contains(newValue)){
            return;
        }
        answer.Add(newValue);
        Display();

    }
    public void Display(){
        answerField.text="";
        for(int i=0;i<answer.Count;i++){
            answerField.text+=answer[i]+" ";
        }
        if(CheckAnswer(answer,2,10,14)){
            answerField.text="Correct.\nCongratulations!!!";
        }
    }
    public static bool IsPerfectSquare(int num) {
    int root = (int)Mathf.Sqrt(num);
    return root * root == num;
    }

    bool CheckAnswer(List<int> array, params int[] elements)
    {
        int index = 0; // Index to keep track of the current element to check
        foreach (int element in array)
        {
            if (element == elements[index]) // Check if the current element matches the element to check
            {
                index++; // Move to the next element to check
                if (index == elements.Length) // Check if all elements have been found
                {
                    return true; // All elements are present in the respective order
                }
            }
        }
        return false; // Elements are not present in the respective order
    }
    public void Reset(){
        answer.Clear();
        answer.Add(0);
        Display();
    }
}
