using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YodaScript : MonoBehaviour
{

    [SerializeField]
    public GameObject dialogueManager;

    [SerializeField]
    private GameObject inventoryRoot;

    //private Conversation conversation;

    private InventoryManager inventoryManager;

    public List<DialogueNode> dialogueNodesSet1;
    public List<DialogueNode> dialogueNodesSet2;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = inventoryRoot.GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(inventoryManager.bookStatus)
        {
            InventorySpace.metYoda = true;
            dialogueManager.GetComponent<Conversation>().setNodes(dialogueNodesSet1);
        } else
        {
            dialogueManager.GetComponent<Conversation>().setNodes(dialogueNodesSet2);
        }
        dialogueManager.GetComponent<Conversation>().setIndex(0);
        dialogueManager.GetComponent<Conversation>().showDialogue();
    }

}
