using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelVanishTimer : MonoBehaviour
{
    public GameObject m_panel;
    bool time_up = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (time_up)
        {
            Debug.Log("Panel Timer time up!");
            m_panel.SetActive(false);
            time_up = false;
        }
    }

    IEnumerator PanelTimer()
    {
        Debug.Log("Panel Timer start!");
        yield return new WaitForSeconds(3);
        time_up = true;
    }

    public void SetupTimer()
    {
        StartCoroutine("PanelTimer");
    }
}
