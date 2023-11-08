using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class OpenDoor : MonoBehaviour
{

    private Animator anim;

    private bool IsAtDoor = false;

    [SerializeField] private TextMeshProUGUI CodeText;
    string codeTextValue = "";
    public string SafeCode;
    public GameObject CodePanel;
    public UnityEvent keypad;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CodeText.text = codeTextValue;

        if (codeTextValue == SafeCode)
        {
            anim.SetTrigger("OpenDoor");
            CodePanel.SetActive(false);
        }

        if(codeTextValue.Length >= 7)
        {
            codeTextValue = "";
        }

        //Debug.Log("funciona");
        if (Input.GetKey(KeyCode.P) && IsAtDoor == true)
        {
            Debug.Log("funciona");
            //CodePanel.SetActive(true);
            keypad.Invoke();
            Debug.Log("P");
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player") 
        {
            IsAtDoor = true;
            Debug.Log("POrta");
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        IsAtDoor = false;
        CodePanel.SetActive(false);
    }

    public void AddDigit(string digit) 
    {
        codeTextValue += digit;
    }
}
