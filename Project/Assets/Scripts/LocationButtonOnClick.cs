using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationButtonOnClick : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject MixedRealityPlayspace;
    public GameObject MainCamera;
    public GameObject fridge;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnClick()
    {



        Vector3 fridgePosition = fridge.transform.TransformPoint(0, 0, 0);
        //Vector3 camPosition = MixedRealityPlayspace.transform.TransformPoint(0, 0, 0);
        Debug.Log(fridgePosition);
        MainCamera.transform.localPosition = new Vector3(0, 0, 0);
        MainCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
        MixedRealityPlayspace.transform.rotation = Quaternion.Euler(0, -90, 0);
        MixedRealityPlayspace.transform.position = fridgePosition + new Vector3(0.33f, 0.21f, 0);


    }
}
