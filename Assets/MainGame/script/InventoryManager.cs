using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform itemContent;
    public Transform inGameItemContent;
    public GameObject inventoryItem;
    public GameObject inGameInventoryItem;

    public int itemCount;



    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
        ++itemCount;
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemDescription = obj.transform.Find("ItemDescription").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName; 
            itemDescription.text = item.itemDescription; 
            itemIcon.sprite = item.itemIcon; 
        }
    }

    public void ListOfItems()
    {
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(inGameInventoryItem, inGameItemContent);
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemIcon.sprite = item.itemIcon;
        }
    }
}
