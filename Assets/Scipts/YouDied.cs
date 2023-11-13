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

    // Update is called once per frame
    public void Exit()
    {
        Application.Quit();
    }
}
