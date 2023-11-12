using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Inventory UI
public class InventoryHUDManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryRoot;

    [SerializeField]
    private GameObject itemsParent;

    [SerializeField]
    private List<GameObject> inventoryList;
    
    private InventoryManager inventoryManager;

    public Button backPack;

    bool buttonStatus = true;

    public void Start()
    {
        inventoryManager = inventoryRoot.GetComponent<InventoryManager>();
        viewInventory();
    }

    public void Awake()
    {
        backPack.onClick.AddListener(viewInventory);
    }

    public void showHUD()
    {
        Dictionary<string, Item> items = inventoryManager.getItems();
        foreach (var itemKvp in items)
        {
            inventoryList[int.Parse(itemKvp.Key)-1].GetComponent<InventorySpace>().setItem(itemKvp.Value);
        }
    }

    public void deleteItem(Item item, string slotIndex)
    {
        inventoryManager.deleteItem(item, slotIndex);
        showHUD();
    }

    public string addItem(Item item)
    {
        string addItemStatus = inventoryManager.addItemToInventory(item);
        showHUD();
        return addItemStatus;
    }

    public void viewInventory()
    {
        buttonStatus = !buttonStatus;
        inventoryRoot.gameObject.SetActive(buttonStatus);
    }

}
 