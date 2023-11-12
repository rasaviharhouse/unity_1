using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust the speed as needed
    public float maxTranslationX = 40.0f; // Maximum distance to move on the X-axis

    private bool movingRight = true;

    [SerializeField]
    public GameObject dialogueManager;

    //private Conversation conversation;

    public List<DialogueNode> dialogueNodes;

    public void Start()
    {
        //conversation = GameObject.Find("DialogueManager").GetComponent<Conversation>();
        //conversation = dialogueManager.GetComponent<Conversation>();
    }

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
            if (transform.position.x <= 10.0f)
            {
                movingRight = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        dialogueManager.GetComponent<Conversation>().setNodes(dialogueNodes);
        dialogueManager.GetComponent<Conversation>().setIndex(0);
        dialogueManager.GetComponent<Conversation>().showDialogue();
    }

}
