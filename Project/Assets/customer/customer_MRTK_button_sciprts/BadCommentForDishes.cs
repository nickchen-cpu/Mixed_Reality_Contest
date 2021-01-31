using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BadCommentForDishes : MonoBehaviour
{
    public CanvasUI_API m_CanvasUI_API;
    void Start()
    {
    }

    public void IncreaseNegtiveVote()
    {
        StartCoroutine(PostRequest("http://23.99.125.231/neg_vote.php"));
    }

    // Post
    IEnumerator PostRequest(string uri)
    {
        WWWForm form = new WWWForm();
        form.AddField("dish_id", "1");
        UnityWebRequest uwr = UnityWebRequest.Post(uri, form);
        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            m_CanvasUI_API.getDishesInfo();
        }
    }

}