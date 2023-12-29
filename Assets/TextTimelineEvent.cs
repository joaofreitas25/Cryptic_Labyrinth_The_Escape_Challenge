using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTimelineEvent : MonoBehaviour
{
    public Text subtitleText;

    void Start()
    {
        // Ensure the subtitle text is initially hidden
        subtitleText.text = "";
    }

    // This method will be called by the Timeline event
    public void ShowText(string text)
    {
        subtitleText.text = text;
    }

    // This method will be called by the Timeline event
    public void HideText()
    {
        subtitleText.text = "";
    }
}