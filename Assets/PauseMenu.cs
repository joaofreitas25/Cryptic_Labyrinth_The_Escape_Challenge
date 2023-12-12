using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;


    public UnityEvent showmenu;
    public UnityEvent hidemenu;

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !In.Instance.inventory)
        {
            GameIsPaused = !GameIsPaused;
            if (GameIsPaused)
            {
                Pause();
            } else
            {
                Resume();
            }
        }
    }

    public void Resume () 
    {
        hidemenu.Invoke();
        Time.timeScale = 1f;
        //GameIsPaused = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }
    public void Resume2()
    {
        hidemenu.Invoke();
        Time.timeScale = 1f;
        GameIsPaused = !GameIsPaused;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    public void Pause ()
    {
        showmenu.Invoke();
        Time.timeScale = 0f;
        //GameIsPaused = true;

        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        UnityEngine.Cursor.visible = true;
    }



    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    

    // Update is called once per frame
    public void Exit()
    {
        Application.Quit();
    }
}
