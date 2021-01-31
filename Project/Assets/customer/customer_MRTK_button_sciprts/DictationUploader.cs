using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DictationUploader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UploadCommment(string str)
    {
        StartCoroutine(PostRequest("http://23.99.125.231/record_comment.php", str));
    }

    // Post
    IEnumerator PostRequest(string url, string comment)
    {
        WWWForm form = new WWWForm();
        form.AddField("dish_id", "1");
        form.AddField("comment", comment);
        Debug.Log($"Upload Comment: {comment}");

        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}