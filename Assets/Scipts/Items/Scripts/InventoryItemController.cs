using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryItemController : MonoBehaviour
{
    Itemv2 Item;
    

    public void RemoveItem()
    {
        In.Instance.Remove(Item);
        Destroy(gameObject);
    }

    public void AddItem(Itemv2 newItem) 
    {
        Item = newItem;
    }

    public void UseItem()
    {
        print("a");
        RemoveItem();
    }
}
