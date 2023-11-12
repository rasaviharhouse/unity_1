using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private TextMeshProUGUI characterName;

    private Transform dialogueBoxPanel;

    public int index = 0;

    public List<TextMeshProUGUI> buttons;

    public List<DialogueNode> nodes;


    
    private Button prevButton;
    private Button nextButton;

    public void Start()
    {
        index = 0;
        //dialogueBoxPanel = transform.Find("DialogueBoxPanel");
        //dialogueBoxPanel.gameObject.SetActive(false);
        gameObject.SetActive(false);
        prevButton = buttons[0].GetComponent<Button>();
        nextButton = buttons[1].GetComponent<Button>();

        nextButton.onClick.AddListener(showNextDialogue);
        prevButton.onClick.AddListener(showPrevDialogue);
    }

    public void setIndex(int startIndex)
    {
        index = startIndex;
    }

    public void setNodes(List<DialogueNode> nodeList)
    {
        nodes = nodeList;
    }

    //public void reponseClicked(int responseIndex)
    //{
    //    int responseToFind = nodes[index].responseIDs[responseIndex];
    //    foreach(DialogueNode node in nodes)
    //    {
    //        if(node.ID == responseToFind)
    //        {
    //            index = nodes.IndexOf(node);
    //            break;
    //        }
    //    }
    //    showNextDialogue();
    //}

    //public void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        index++;
    //        showDialogue();
    //    }
    //}

    //public void Awake()
    //{

    //}

    public void showPrevDialogue()
    {
        index--;
        showDialogue();
    }

    public void showNextDialogue()
    {
        index++;
        showDialogue();
    }

    public void showDialogue()
    {
        buttons[0].text = index == 0 ? string.Empty : "<< Prev";
        buttons[1].text = index == nodes.Count-1 ? "Finish" : "Next >>";

        if (index>=0 && index < nodes.Count)
        {
            //dialogueBoxPanel.gameObject.SetActive(true);
            gameObject.SetActive(true);
            text.text = string.Empty;

            characterName.text = nodes[index].name + ":";

            StartCoroutine(slowPrintText(0.1f));
            //int responseIndex = 0;
            //foreach (string response in nodes[index].responses)
            //{
            //    buttons[responseIndex++].text = response;
            //}
        }
        else
        {
            //dialogueBoxPanel = transform.Find("DialogueBoxPanel").gameObject;
            //index = -1;
            //dialogueBoxPanel.gameObject.SetActive(false);
            gameObject.SetActive(false);
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
