using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Class that represents the space for each inventory item
public class InventorySpace : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryHUDManager;

    [SerializeField]
    public GameObject textObject;

    public Button itemButton;

    // This item is set from the parameter in setItem method.
    public Item item;

    private string slotIndex;

    public static bool metYoda = false;


    // The below 2 variables are to just store the image and text of the Item.
    public TextMeshProUGUI text;

    public Image image;

    public HealthBar healthBar;    // Reference to the Health Bar

    public void Start()
    {
        inventoryHUDManager = GameObject.Find("Canvas");
        slotIndex = this.name[name.Length - 1].ToString();
    }

    public void Awake()
    {
        itemButton.onClick.AddListener(clearItem);
    }

    public void setItem(Item itemToSet)
    {
        item = itemToSet;
        image.sprite = item.getSprite();
        textObject.SetActive(true);
        text.SetText(item.getName());
    }

    // Call this method when user clicks on an item to remove it from inventory
    public void clearItem()
    {
        if ((text.text.Equals("The Book of Mysteries") && !metYoda) || text.text.Equals("Empty"))
        {
            return;
        }
        else if (text.text.Equals("Health"))
        {
            if(Collision.playerHealth < Collision.maxPlayerHealth)
            {
                Collision.playerHealth++;
                healthBar.setHealth(Collision.playerHealth);
            }
            else
            {
                return;
            }
            
        }
        image.sprite = null;
        text.SetText("Empty");
        inventoryHUDManager.GetComponent<InventoryHUDManager>().deleteItem(item, slotIndex);
    }
}
