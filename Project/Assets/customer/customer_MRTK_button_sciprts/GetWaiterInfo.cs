using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System;

public class GetWaiterInfo : MonoBehaviour
{
    private class WaiterInfo
    {
        public bool success_flag;
        public string name;
    }
    private int waiter_id;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetWaiterName(int id)
    {
        waiter_id = id;
        StartCoroutine(PostRequest("http://23.99.125.231/get_waiter_name.php"));
    }

    IEnumerator PostRequest(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("waiter_id", waiter_id);
        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();
        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending:" + uwr.error);
            yield return 0;
        }

        Debug.Log("Received: " + uwr.downloadHandler.text);
        WaiterInfo info = JsonUtility.FromJson<WaiterInfo>(uwr.downloadHandler.text);
        Debug.Log(info.name);
    }
}