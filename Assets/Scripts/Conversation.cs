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

    public int index = 0;

    public List<TextMeshProUGUI> buttons;

    public List<DialogueNode> nodes;
    
    private Button prevButton;
    private Button nextButton;

    public void Start()
    {
        index = 0;
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
            gameObject.SetActive(true);
            text.text = string.Empty;

            characterName.text = nodes[index].name + ":";

            StartCoroutine(slowPrintText(0.1f));
        }
        else
        {
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
