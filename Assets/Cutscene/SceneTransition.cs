using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string Game; // The name of the next scene

    public void LoadNextScene()
    {
        SceneManager.LoadScene(Game);
    }
}