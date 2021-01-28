using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.UI;

public class rankingboard : MonoBehaviour
{
    public string url;  //url是指要連結的php檔案位置,此範例為127.0.0.1/select.php
    HttpWebRequest request;

    void Update()
    { 
 StartCoroutine (reflashboard ());
    }

    IEnumerator reflashboard()
    {
 yield return new WaitForSeconds (2f);
 request = (HttpWebRequest)WebRequest.Create(url);
 //request.Method = "POST";
 request.ContentType = "application/x-www-form-urlencoded";
 
 WebResponse response = request.GetResponse();
 Stream stream = response.GetResponseStream();

 StreamReader sr = new StreamReader(stream);

 rankinginfo = sr.ReadToEnd();
 string[] word = rankinginfo.Trim().Split(',');

 //word[0]就是讀到的第一筆資料 
    }
}
