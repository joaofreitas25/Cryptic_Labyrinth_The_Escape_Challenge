using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class In : MonoBehaviour
{
    public static In Instance;
    public List<Itemv2> Items = new List<Itemv2>();


    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Itemv2 item)
    {
        Items.Add(item);
    }

    private void Update()
    {
        OpenInv();
    }
    public void OpenInv()
    {
        if (Input.GetKeyDown(KeyCode.I))
            ListItems();
    }

    public void ListItems()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
    }

}
