using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Timeline/TextEvents")]
public class TextEvents : ScriptableObject
{
    // Start is called before the first frame update

    public UnityEvent OnShowText;
    public UnityEvent OnHideText;

}
