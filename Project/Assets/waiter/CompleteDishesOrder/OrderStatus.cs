using UnityEngine;
using System.Collections;
using System.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.Networking;

public class OrderStatus : MonoBehaviour
{
    public async void TaskOnClick()
    {
        bool test = await CheckedOrderStatus(8);
        Debug.Log("test status: " + test);
    }
    public async Task<bool> CheckedOrderStatus(int id)
    {
        string url = "http://23.99.125.231/get_order_by_id.php";
        WWWForm form = new WWWForm();
        form.AddField("order_id", id.ToString());
        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        uwr.SendWebRequest();
        while (!uwr.isDone)
        {
            await Task.Delay(100);
        }
        if (uwr.isHttpError || uwr.isNetworkError)
        {
            throw new System.Exception();
        }
        return JsonUtility.FromJson<OrderInfo>(uwr.downloadHandler.text).is_finished; ;
    }
}
