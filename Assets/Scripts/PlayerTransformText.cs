using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTransformText : MonoBehaviour
{
    public Text position_x;
    public Text position_z;

    public Text rotation_y;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        if (player != null)
        {
            position_x.text = "x position: " + player.position.x.ToString();
            position_z.text = "z position: " + player.position.z.ToString();
            rotation_y.text = "y rotation: " + player.rotation.eulerAngles.y.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            position_x.text = "x position: " + player.position.x.ToString();
            position_z.text = "z position: " + player.position.z.ToString();
            rotation_y.text = "y rotation: " + player.rotation.eulerAngles.y.ToString();
        }
    }
}
