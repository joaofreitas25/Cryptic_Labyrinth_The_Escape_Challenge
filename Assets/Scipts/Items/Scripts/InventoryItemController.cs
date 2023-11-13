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
        if (Item.id == 1)
        { 
            timer1.Instance.comer();
            Debug.Log("Comer");
            RemoveItem();
        }
        else if (Item.id == 2)
        {
            timer1.Instance.beber();
            Debug.Log("Beber");
            RemoveItem();
        }
        else if (Item.id == 3)
        {
            timer1.Instance.medKit();
            Debug.Log("MedKit");
            RemoveItem();
        }
    }
}
