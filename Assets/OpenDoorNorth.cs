using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class OpenDoorNorth : MonoBehaviour
{

    private Animator anim;

    private bool IsAtDoor = false;

    [SerializeField] private TextMeshProUGUI CodeText;
    string codeTextValue = "";
    public string SafeCode;
    public GameObject CodePanel;
    public UnityEvent keypad;
    public UnityEvent closekeypad;
    public UnityEvent showtext;
    public UnityEvent hidetext;

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
            Time.timeScale = 1;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;
        }

        if (codeTextValue.Length >= 7)
        {
            codeTextValue = "";
        }

        //Debug.Log("funciona");
        if (Input.GetKey(KeyCode.P) && IsAtDoor == true)
        {
            Debug.Log("funciona");
            //CodePanel.SetActive(true);
            keypad.Invoke();
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Debug.Log("P");
        }
        if (Input.GetKey(KeyCode.Escape) && IsAtDoor == true)
        {
            Debug.Log("funciona");
            //CodePanel.SetActive(true);
            closekeypad.Invoke();
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Debug.Log("P");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsAtDoor = true;
            Debug.Log("POrta");
            showtext.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IsAtDoor = false;
        CodePanel.SetActive(false);
        Time.timeScale = 1;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        hidetext.Invoke();
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
}
