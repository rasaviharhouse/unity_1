using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public int playerHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        
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
            playerHealth = playerHealth > 0 ? playerHealth - 20 : 0;
        }

        else if (other.CompareTag("Health"))
        {
            // Handle health pack behavior.
            Debug.Log("Player found a health pack.");
            playerHealth = playerHealth <100 ? playerHealth + 20 : 100;
        }

        Destroy(other.gameObject);

        if(playerHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
