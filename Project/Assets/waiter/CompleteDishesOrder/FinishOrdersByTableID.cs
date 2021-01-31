using UnityEngine;
using System.Collections;
using System.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.Networking;

public class FinishOrdersByTableID : MonoBehaviour
{

    public async void TaskOnClick()
	{
        int test = await MakeOrderFinishedByTable(1);
        Debug.Log("FinishOrdersByTableID!");
	}
    public async Task<int> MakeOrderFinishedByTable(int id)
    {
        string url = "http://23.99.125.231/set_finished_by_tableid.php";
        WWWForm form = new WWWForm();
        form.AddField("table_id", id.ToString());
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
        return 0;
    }
}
