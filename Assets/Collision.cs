using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{

    public static int playerHealth;
    public static int maxPlayerHealth = 5;

    public HealthBar healthBar;    // Reference to the Health Bar

    public Restart canvasRestart; // Reference to the Canvas Restart script

    [SerializeField]
    public InventoryHUDManager inventory;

    [SerializeField]
    public Item HealthItem;

    [SerializeField]
    public Item BookItem;

    [SerializeField]
    public Item JewelItem;

    [SerializeField]
    public Item DaggerItem;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxPlayerHealth;
        healthBar.setMaxHealth(maxPlayerHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        string message = "Added";

        if (other.CompareTag("Hazard"))
        {
            // Player entered the trigger zone of this object.
            Debug.Log("Player hit a hazard.");
            playerHealth = playerHealth > 0 ? playerHealth - 1 : 0;
            updatePlayerHealth();
        }

        else if (other.CompareTag("Health"))
        {
            // Handle health pack behavior.
            Debug.Log("Player found a health pack.");
            message = inventory.addItem(HealthItem);
        }

        else if (other.CompareTag("Book"))
        {
            Debug.Log("Player found the book of mysteries");
            message = inventory.addItem(BookItem);
        }
        else if (other.CompareTag("Jewel"))
        {
            Debug.Log("Player found a Jewel");
            message = inventory.addItem(JewelItem);
        }
        else if (other.CompareTag("Dagger"))
        {
            Debug.Log("Player found a Dagger");
            message = inventory.addItem(DaggerItem);
        }

        if(message.Equals("Added"))
        {
            Destroy(other.gameObject);
        }

    }

    public void updatePlayerHealth()
    {
        healthBar.setHealth(playerHealth);

        if (playerHealth == 0)
        {
            Destroy(this.gameObject);
            canvasRestart.ShowRestartMessage();
        }
    }
}
