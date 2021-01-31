using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System;

public class CanvasUI_API : MonoBehaviour
{
    public TMP_Text DishesID;
    public TMP_Text DishesName;
    public TMP_Text numOfGood;
    public TMP_Text numOfBad;
    public Text MessageText;
    public Text CommentText;
    public TMP_Text calorieText;
        

    class DishesInfo
    {
        public string name;
        public int calorie;
        public int pos_vote;
        public int neg_vote;
        public string[] Comments;
    }


    // Start is called before the first frame update
    void Start()
    {
        getDishesInfo();
    }

    public void getDishesInfo()
    {
        string url = "http://23.99.125.231/get_dishesInfo.php";
        string structName = "DishesInfo";
        getTargetInfo(url, structName);
    }


    void getTargetInfo(string url, string structName)
    {
        if (structName == "DishesInfo")
        {
            StartCoroutine(PostRequest(url));
        }
    }

    

    IEnumerator PostRequest(string url)
    {
        Debug.Log(DishesID.text);
        WWWForm form = new WWWForm();
        form.AddField("dish_id", DishesID.text);
        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending:" + uwr.error);
            yield return 0;
        }

        Debug.Log("Received: " + uwr.downloadHandler.text);
        Debug.Log(JsonUtility.FromJson<DishesInfo>(uwr.downloadHandler.text));
        DishesInfo result = JsonUtility.FromJson<DishesInfo>(uwr.downloadHandler.text);

        displayDishesInfo(result);
    }

    void displayDishesInfo(DishesInfo result)
    {
        DishesName.text = result.name;
        numOfGood.text = result.pos_vote + "";
        numOfBad.text = result.neg_vote + "";
        Debug.Log(result.Comments.Length);
        MessageText.text = "";
        for (int i = result.Comments.Length - 1; i >= result.Comments.Length - 5 && i >= 0; i--)
            MessageText.text += (result.Comments.Length - i) + ". " + result.Comments[i] + "\n";
        calorieText.text = result.calorie + " calorie";


    }

}




