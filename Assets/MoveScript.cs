using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust the speed as needed
    public float maxTranslationX = 40.0f; // Maximum distance to move on the X-axis

    private bool movingRight = true;

    void Update()
    {
        // Translate the object along the X-axis
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= maxTranslationX)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= 6.0f)
            {
                movingRight = true;
            }
        }
    }
}
