using UnityEngine;

public class Tag : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.tag = "Obstacle";
        }
    }
}
