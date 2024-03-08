using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;
using System.Collections.Generic;

[System.Serializable]
public class MyData
{
    public string response;
    public string threadId;
}

public class ApiCaller : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private const string apiUrl = "https://assistant-ai-server.onrender.com/assistant/dunity";
    
    public void ApiCall(string a, string b)
    {
        StartCoroutine(PostDataToApi(a, b));
    }

    IEnumerator PostDataToApi(string input, string thread)
    {
        // Create a sample JSON data (replace this with your actual data)
              // Concatenate name and age into the JSON string
        Debug.Log(input);
        string jsonData = "";
        if (thread == null)
        {
            jsonData = $"{{\"userText\": \"{input}\"}}";
        }else{
            jsonData = $"{{\"userText\": \"{input}\", \"threadId\": \"{thread}\"}}";
        }
        Debug.Log(jsonData);
        using UnityWebRequest webRequest = new(apiUrl, "POST");
        // Set the request body
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        // Set the Content-Type header to specify JSON data
        webRequest.SetRequestHeader("Content-Type", "application/json");

        // Send the request
        yield return webRequest.SendWebRequest();

        // Check if the request was successful
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("POST request successful!");

            MyData myData = JsonUtility.FromJson<MyData>(webRequest.downloadHandler.text);
            dialogueManager.threadId = myData.threadId;
            dialogueManager.DisplayNextSentence(myData.response); 

        }
        else
        {
            Debug.LogError($"Error: {webRequest.error}");
        }
    }
}
