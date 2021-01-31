using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttachCameraRuntime : MonoBehaviour
{
    public Canvas MessageCanvas;

    // Start is called before the first frame update
    void Start()
    {
        


    }
    bool setParentflag = true;

    // Update is called once per frame
    void Update()
    {
        if (MessageCanvas.worldCamera == null)
        {
            Debug.Log("No World Camera");
        }
        else if (setParentflag)
        {
            // worldCamera Exist, set parent of canvas as camera
            MessageCanvas.transform.SetParent(MessageCanvas.worldCamera.transform, false);
            MessageCanvas.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 6.5f);
            setParentflag = false;
            Debug.Log("World Camera");
        }
    }
}
