using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDied : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    private void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    public void Exit()
    {
        Application.Quit();
    }
}
