using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEventManager : MonoBehaviour
{
    public TextEvents textEvents;

    public void ShowText()
    {
        textEvents.OnShowText.Invoke();
    }

    public void HideText()
    {
        textEvents.OnHideText.Invoke();
    }
}
