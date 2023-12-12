using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class In : MonoBehaviour
{
    public static In Instance;
    public List<Itemv2> Items = new List<Itemv2>();


    public Transform ItemContent;
    public GameObject InventoryItem;
    public UnityEvent openinv;
    public UnityEvent closeinv;
    public bool inventory = false;

    public InventoryItemController[] InventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Itemv2 item)
    {
        Items.Add(item);
    }

    public void Remove(Itemv2 item)
    {
        Items.Remove(item);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory = !inventory;
            if (inventory)
            {
                OpenInv2();
            }
            else
            {
                CloseInv();
            }
        }
        //OpenInv();
        //CloseInv();
    }
    public void OpenInv()
    {
        if (Input.GetKeyDown(KeyCode.I) && !inventory)
        {
            OpenInv2();
        }
    }
    public void OpenInv2()
    {
        ListItems();
        openinv.Invoke();
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        
    }
    public void CloseInv()
    {
        
            Time.timeScale = 1;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;
            closeinv.Invoke();
            
            CleanContent();
            print("a");
        
    }
    


    public void ListItems()
    {
        
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
        SetInventoryItems();
    }


    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i <Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }

    public void CleanContent()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
    }

}
