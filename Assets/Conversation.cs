using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private TextMeshProUGUI characterName;
    [SerializeField]
    private List<TextMeshProUGUI> buttons;
    [SerializeField]
    private List<DialogueNode> nodes;

    private GameObject dialogueBoxPanel;

    private int index;
    
    public void Start()
    {
        index = 0;
        dialogueBoxPanel = GameObject.Find("DialogueBoxPanel");
        dialogueBoxPanel.SetActive(false);
    }

    public void reponseClicked(int responseIndex)
    {
        int responseToFind = nodes[index].responseIDs[responseIndex];
        foreach(DialogueNode node in nodes)
        {
            if(node.ID == responseToFind)
            {
                index = nodes.IndexOf(node);
                break;
            }
        }
        showNextDialogue();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            showNextDialogue();
        }
    }

    public void showNextDialogue()
    {
        if (index < nodes.Count)
        {
            dialogueBoxPanel.SetActive(true);
            text.text = string.Empty;
            characterName.text = nodes[index].name + ":";
            StartCoroutine(slowPrintText(0.1f));
            int responseIndex = 0;
            foreach (string response in nodes[index].responses)
            {
                buttons[responseIndex++].text = response;
            }
        }
        else
        {
            dialogueBoxPanel.SetActive(false);
        }
    }

    public IEnumerator slowPrintText(float textSpeed)
    {
        foreach (char c in nodes[index].text.ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
