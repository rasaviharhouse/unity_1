using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public int playerHealth;
    public int maxPlayerHealth = 5;

    public HealthBar healthBar;    // Reference to the Health Bar

    public Restart canvasRestart; // Reference to the Canvas Restart script

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
        if (other.CompareTag("Hazard"))
        {
            // Player entered the trigger zone of this object.
            Debug.Log("Player hit a hazard.");
            playerHealth = playerHealth > 0 ? playerHealth - 1 : 0;
        }

        else if (other.CompareTag("Health"))
        {
            // Handle health pack behavior.
            Debug.Log("Player found a health pack.");
            playerHealth = playerHealth < maxPlayerHealth ? playerHealth + 1 : maxPlayerHealth;
        }

        Destroy(other.gameObject);

        healthBar.setHealth(playerHealth);

        if (playerHealth == 0)
        {
            Destroy(this.gameObject);
            canvasRestart.ShowRestartMessage();
        }
    }
}
