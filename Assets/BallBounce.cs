using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xPos = transform.position.x;
        float yPos = transform.position.y;
        float zPos = transform.position.z;
        transform.Translate(xPos, yPos + 1.0f * Time.deltaTime, zPos);

        if (transform.position.y > 5.0f)
        {

            Vector3 newPos = new Vector3(xPos, 1.0f, zPos);
            transform.position = newPos;
        }
    }

    void FixedUpdate()
    {

    }
}
