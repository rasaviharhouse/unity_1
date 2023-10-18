using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotate : MonoBehaviour
{

    public GameObject centerBall;

    public GameObject ball2;

    public GameObject ball3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Ball 1
        transform.RotateAround(centerBall.transform.position, Vector3.up, 20 * Time.deltaTime);

        // Ball2
        ball2.transform.RotateAround(centerBall.transform.position, Vector3.right, 25 * Time.deltaTime);

        // Ball3
        ball3.transform.RotateAround(centerBall.transform.position, Vector3.left, 30 * Time.deltaTime);

        // Center Ball
        centerBall.transform.Rotate(0, 1.0f, 0);

    }
}
