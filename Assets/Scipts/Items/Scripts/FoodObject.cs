using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New food object", menuName = "Inventory System/Items/Food")]
public class NewBehaviourScript : ItemObject
{
    public void Awake()
    {
        type = ItemType.Food;
    }
}
