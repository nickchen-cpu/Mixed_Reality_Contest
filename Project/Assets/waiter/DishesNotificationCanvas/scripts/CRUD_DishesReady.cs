using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CRUD_DishesReady : MonoBehaviour
{
    private SortedDictionary<int, GameObject> DishesReadyDict;

    public GameObject DishesReady;

    public int DeleteID = -1;
    
    public Transform Canvas;

    private int ID = 1; // ID start from 1

    public OrderManager m_OrderManager;

    // Start is called before the first frame update
    async void Start()
    {
        DishesReadyDict = new SortedDictionary<int, GameObject>();
        // InvokeRepeating("CreateNewDishesReady", 1.0f, 15.0f);

        OrderInfo[] OrderInfos = await m_OrderManager.GetOrdersByTableID(1);


        DisplayDishesInfo(OrderInfos);
    }

    public void CreateNewDishesReady(string tableName, string dishName)
    {
        Debug.Log("create triggered!");
        GameObject DishesR = Instantiate(DishesReady, Vector3.zero, Quaternion.identity); // Create a new DishesReady Object
        DishesR.transform.SetParent(Canvas, false); // set Canvas as parent
        DishesR.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = tableName + " - " + dishName;
        DishesReadyDict.Add(ID, DishesR);

        Debug.Log(ID);
        ID += 1;
        // set all DishesReady object to specific position on 2D Canvas
        setPositionOnCanvas(DishesReadyDict);
        
    }

    public void DeleteDishesByID()
    {
        int removeTargetID = DeleteID;
        int DishesReadyDictSize = DishesReadyDict.Count;

        if (DeleteID == -1)
        {
            removeTargetID = DishesReadyDict.Keys.Max();
    
        }


        Destroy(DishesReadyDict[removeTargetID]); // Destroy on Game scene
        DishesReadyDict.Remove(removeTargetID); // Remove from  List 

        
        Debug.Log(DishesReadyDict.Count);
        if (DishesReadyDict.Count == 0){
            ID = 1;
        }
        else{
            ID = DishesReadyDict.Keys.Max() + 1; // new dish index start from Maximum ID
        }

        setPositionOnCanvas(DishesReadyDict);
           
    }

    void setPositionOnCanvas(SortedDictionary<int, GameObject> DishesReadyDict)
    {
        Debug.Log("Set Position");  
        int Size = DishesReadyDict.Count;
        int PosX = 230, PosY = -120; // first position of Object on canvas is PosX->230 PosY->(-120)
        int HeightOfObject = 70;
        int idxOnScene = 0;
        foreach (KeyValuePair<int, GameObject> item in DishesReadyDict)
        {
            item.Value.GetComponent<RectTransform>().anchoredPosition = new Vector2(PosX, PosY + (-HeightOfObject) * idxOnScene);
            idxOnScene += 1;
        }

    }

    int getDishesDictSize(SortedDictionary<int, GameObject> DishesReadyDict)
    {
        Debug.Log($"DishesReadyDict Size: {DishesReadyDict.Count}");

        return DishesReadyDict.Count;
    }


    void getDishesIndexCanvasPosition(int index = 0)
    {
        Debug.Log(DishesReadyDict[index].GetComponent<RectTransform>().anchoredPosition);
    }

    void DisplayDishesInfo(OrderInfo[] test)
    {
        string[] dishNames = { "Pasta", "Dumpling", "sandwich", "Soup" };
        for (int i = 0; i < test.Length; i++)
            CreateNewDishesReady("A", dishNames[i]);
        Debug.Log($"test[0].size {test[0].size}");
    }
}

