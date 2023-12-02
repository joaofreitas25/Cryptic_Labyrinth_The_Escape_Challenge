using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryItemController : MonoBehaviour
{
    Itemv2 Item;
    public UnityEvent Puzzle1;
    public UnityEvent Puzzle2;
    public UnityEvent Puzzle3;
    public UnityEvent Puzzle4;
   

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
        else if(Item.id == 4)
        {
            Puzzle1.Invoke();
            Debug.Log("Puzzle1");
           

        }
        else if (Item.id == 5)
        {
            Puzzle2.Invoke();
            Debug.Log("Puzzle2");
            

        }
        else if (Item.id == 6)
        {
            Puzzle3.Invoke();
            Debug.Log("Puzzle3");
            

        }
        else if (Item.id == 7)
        {
            Puzzle4.Invoke();
            Debug.Log("Puzzle4");

        }
    }
}
