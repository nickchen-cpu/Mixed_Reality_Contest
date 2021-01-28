using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Net;

public class ButtonClick : MonoBehaviour {
{
    public string url;  //url是指要連結的php檔案位置,此範例為127.0.0.1/insert.php

    void Update()
    { 
 WWWForm form = new WWWForm ();
 form.AddField ("score", score.ToString ());    //score是php檔案內的$_POST['score'],單引號內的變數
 form.AddField ("groups", team_name);           //groups是$_POST['groups'],單引號內的變數
        for (int i = 0; i < DBcolumn.Length; i++)
 {
     form.AddField (DBcolumn[i], inputfield[i].text);
 }
 WWW www = new WWW (url, form);
 StartCoroutine (updatesco (www));
    }

    IEnumerator (updatesco (WWW www){
 yield return www;
    }
}
