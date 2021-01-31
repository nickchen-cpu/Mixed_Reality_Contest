using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServiceBell : MonoBehaviour
{
    public int table_id;

    void Start()
    {
    }

    public void SetServiceBell()
    {
        StartCoroutine(PostRequest("http://23.99.125.231/on_waiting_waiter.php"));
    }

    public void ResetServiceBell()
    {
        StartCoroutine(PostRequest("http://23.99.125.231/off_waiting_waiter.php"));
    }

    public void SetWaterBell()
    {
        StartCoroutine(PostRequest("http://23.99.125.231/on_waiting_water.php"));
    }

    public void ResetWaterBell()
    {
        StartCoroutine(PostRequest("http://23.99.125.231/off_waiting_water.php"));
    }

    // Post
    IEnumerator PostRequest(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("table_id", table_id);
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
