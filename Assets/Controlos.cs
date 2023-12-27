using UnityEngine;
using UnityEngine.Events;

public class MostrarControles : MonoBehaviour
{
    public GameObject janelaControles;
    public UnityEvent controllimg;

    void Start()
    {
        // Desativa a janela de controles no início do jogo
        //janelaControles.SetActive(false);
    }

    public void MostrarOcultarControles()
    {
        // Inverte o estado de ativação da janela de controles
        //janelaControles.SetActive(!janelaControles.activeSelf);
        controllimg.Invoke();
    }
}

