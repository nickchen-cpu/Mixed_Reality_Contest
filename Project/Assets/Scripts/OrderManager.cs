using UnityEngine;
using System.Collections;
using System.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.Networking;
[System.Serializable]
public class OrderInfo
{
    public int size;
    public int id;
    public bool is_done;
    public bool is_finished;
    public int waiter_id;
    public int dish_id;
    public int table_id;
    public int time;
    // time 先不要做​
}
public class OrderManager : MonoBehaviour
{
    List<OrderInfo> orders;
    int updateID;
    public Transform dish_prefab;

    void Start()
    {
        orders = new List<OrderInfo>();
        updateID = 0;
    }
    
    public async void deleteOrderById(int id)
    {
        string url = "http://23.99.125.231/delete_order_by_id.php";
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
    }

    // Update is called once per frame
    async void Update()
    {


        // ID在送出前(拿起不算) 都在updateID之後
        // 找到全部在updateID之後的新的dish 並且not is_done

        // 以大寫開頭，後面一律小寫
        // TODO 取得下面這串資料
        /*

        OrderInfo[] ordersByIdGreaterThanUpdateIdAndIsFinishedAndNotIs_done =  await ordersBytIdGreaterThanUpdateIdAndIsFinishedAndNotIs_done(updateID);
        
        for(int i = 0; ordersByIdGreaterThanUpdateIdAndIsFinishedAndNotIs_done != null &&
                       i < ordersByIdGreaterThanUpdateIdAndIsFinishedAndNotIs_done.Length && orders.Count <= 4; i++)
        {
            if(ordersByIdGreaterThanUpdateIdAndIsFinishedAndNotIs_done[i].id > updateID)
            {
                // 新增這個order到queue中並且增加updateID
                orders.Add(ordersByIdGreaterThanUpdateIdAndIsFinishedAndNotIs_done[i]);
                updateID = ordersByIdGreaterThanUpdateIdAndIsFinishedAndNotIs_done[i].id;

                Transform new_dish = Instantiate(dish_prefab, new Vector3(0, 0, 0), Quaternion.identity);
                new_dish.transform.parent = transform;
                new_dish.transform.localPosition = new Vector3(0, 0, 0);
                // TODO: 新增訊息
            }

        }


        // 找到目前在queue裡的至多4個id 如果是is_done 則刪除

        for(int i = 0; i < orders.Count; i++)
        {
            // TODO: 取得orderById
            OrderInfo orderById = await ordersById(orders[i].id);

            if (orderById.is_done)
            {
                orders.RemoveAt(i);
                i -= 1;
            }
        }
        */
    }

    public async Task<OrderInfo[]> ordersBytIdGreaterThanUpdateIdAndIsFinishedAndNotIs_done(int id)
    {
        // 找到所有 id大於UpdateID and is_finished and not is_done 的 orderinfo
        // 回傳符合條件的OrderInfo
        string url = "http://23.99.125.231/get_order_greater_than_update.php";
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
        
        if (uwr.downloadHandler.text.Equals("3: Not exists"))
            return null;
        return JsonHelper.getJsonArray<OrderInfo>(uwr.downloadHandler.text);
    }
    public async Task<OrderInfo> ordersById(int id)
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
        return JsonUtility.FromJson<OrderInfo>(uwr.downloadHandler.text);
    }

    public async Task<OrderInfo[]> GetOrdersByTableID(int table_id)
    {
        // 找到所有 id大於UpdateID and is_finished and not is_done 的 orderinfo
        // 回傳符合條件的OrderInfo
        string url = "http://23.99.125.231/get_order_by_tableid.php";
        WWWForm form = new WWWForm();
        form.AddField("table_id", table_id.ToString());
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

        return JsonHelper.getJsonArray<OrderInfo>(uwr.downloadHandler.text);
    }


}
public class JsonHelper
{
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }
    [Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}