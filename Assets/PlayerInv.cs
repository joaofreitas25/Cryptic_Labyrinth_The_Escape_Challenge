using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{
    public InventoryObjects inventory;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<ItemInv>();

        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
