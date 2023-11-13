using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public float currentCapacity = 0;
    public float totalCapacity = 5;

    public Dictionary<string, Item> items = new Dictionary<string, Item>();

    private const string ADDED_ITEM_SUCCESS = "Added";

    public bool bookStatus = false;

    public string addItemToInventory(Item item)
    {
        string message = checkConstraints(item);
        if (!message.Equals("valid"))
        {
            return message;
        }
        for (int i = 1; i <= totalCapacity; i++)
        {
            if (!items.TryGetValue(i.ToString(), out Item existingItem))
            {
                items[i.ToString()] = item;
                currentCapacity++;
                break;
            }
        }
        return ADDED_ITEM_SUCCESS;
    }

    public Dictionary<string, Item> getItems()
    {
        return items;
    }

    public void deleteItem(Item item, string slotIndex)
    {
        items.Remove(slotIndex);
        currentCapacity--;
    }

    public string checkConstraints(Item item)
    {
        if (items.Count >= totalCapacity)
        {
            return "Backpack is full!";
        }
        if (item.getName().Equals("The Book of Mysteries"))
        {
            if (bookStatus)
            {
                return "Picked the book already!";
            }
            else
            {
                bookStatus = true;
            }
        }
        return "valid";
    }
}
