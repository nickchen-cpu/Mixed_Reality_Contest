using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.UI;

public class DictationController : MonoBehaviour
{
    DictationHandler dictation;
    public Text textDisplay;
    public DictationUploader uploader;

    // Start is called before the first frame update
    void Start()
    {
        dictation = GetComponent<DictationHandler>();
    }

    public void DictationHypothesis(string text)
    {
        Debug.Log($"DictationHypothesis: {text}");
        textDisplay.text = text;
    }

    public void DictationResult(string text)
    {
        Debug.Log($"DictationResult: {text}");
        textDisplay.text = text;
    }

    public void DictationStart()
    {
        if (dictation != null)
        {
            dictation.StartRecording();
            textDisplay.text = "Start";
            Debug.Log("Start");
        }
    }
    public void DictationEnd()
    {
        if (dictation != null)
        {
            dictation.StopRecording();
            Debug.Log("End");
            Debug.Log(textDisplay.text);
            uploader = GetComponent<DictationUploader>();
            uploader.UploadCommment(textDisplay.text);
        }
    }
}