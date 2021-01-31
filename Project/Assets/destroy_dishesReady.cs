using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_dishesReady : MonoBehaviour
{
    public GameObject DishesNotificationCanvas; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy_DishesReady()
    {
        int Destroy_IdxStart = 4;
        int i = 0;

        foreach (Transform child in DishesNotificationCanvas.transform)
        {
            if (i >= 4) Destroy(child.gameObject);
            i++;
        }
    }
}
