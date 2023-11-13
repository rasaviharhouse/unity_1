using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    public float moveSpeed = 5.0f;
    public float jumpForce = 7.0f;

    private Rigidbody playerRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Started!");
        if (player is null)
        {
            player = GameObject.Find("Player");
        }

        playerRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // Along Z-Axis
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("Pressed W!");
            transform.Translate(new Vector3(0.0f, 0.0f, 2.0f * moveSpeed * Time.deltaTime));

        }
        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("Pressed S!");
            transform.Translate(new Vector3(0.0f, 0.0f, -2.0f * moveSpeed * Time.deltaTime));

        }

        // Along X-Axis
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Pressed A!");
            transform.Translate(new Vector3(-2.0f * moveSpeed * Time.deltaTime, 0.0f, 0.0f));

        }
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Pressed D!");
            transform.Translate(new Vector3(2.0f * moveSpeed * Time.deltaTime, 0.0f, 0.0f));
        }

        // Along Y-Axis
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Pressed Space!");
            transform.Translate(new Vector3(0.0f, 10.0f * jumpForce * Time.deltaTime, 0.0f));
        }
    }


}
