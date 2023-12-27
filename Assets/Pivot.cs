using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public void MovePivotToCorner(Vector3 cornerPosition)
    {
        // Calcula a diferen�a entre a posi��o do novo pivot e a posi��o atual
        Vector3 offset = cornerPosition - transform.position;

        // Move todos os filhos em rela��o ao novo pivot
        foreach (Transform child in transform)
        {
            child.position += offset;
        }

        // Define a posi��o do objeto principal como o novo pivot
        transform.position = cornerPosition;
    }

    // Exemplo de uso:
    void Start()
    {
        // Chame isso de algum lugar do seu c�digo
        Vector3 novoCanto = new Vector3(10f, 0f, 5f);
        MovePivotToCorner(novoCanto);
    }
}
