using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        else if(Item.id == 4)
        {
            timer1.Instance.puzzle1();
            Debug.Log("Puzzle1");
           

        }
        else if (Item.id == 5)
        {
            timer1.Instance.puzzle2();
            Debug.Log("Puzzle2");
            

        }
        else if (Item.id == 6)
        {
            timer1.Instance.puzzle3();
            Debug.Log("Puzzle3");
            

        }
        else if (Item.id == 7)
        {
            timer1.Instance.puzzle4();
            Debug.Log("Puzzle4");

        }
        else if (Item.id == 8)
        {
            timer1.Instance.letter();
            Debug.Log("Letter");

        }
    }
}
