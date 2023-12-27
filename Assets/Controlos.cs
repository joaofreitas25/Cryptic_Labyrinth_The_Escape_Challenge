using UnityEngine;

public class MostrarControles : MonoBehaviour
{
    public GameObject janelaControles;

    void Start()
    {
        // Desativa a janela de controles no in�cio do jogo
        janelaControles.SetActive(false);
    }

    public void MostrarOcultarControles()
    {
        // Inverte o estado de ativa��o da janela de controles
        janelaControles.SetActive(!janelaControles.activeSelf);
    }
}

