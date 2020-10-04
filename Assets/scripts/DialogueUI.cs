using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI instance {get; private set;}
    public DialogueNode enteryPoint;
    public TextMeshProUGUI npcTextMesh;
    public DialogueColors colors;
    public TextMeshProUGUI[] optionTextMeshes;
    private DialogueNode currentDialogueNode;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        loadDialogueNode(enteryPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadDialogueNode(DialogueNode node) {
        if (node == null)
            return;
        currentDialogueNode = node;
        string[] optionTexts = new string[node.options.Length];
        for (int i = 0; i < optionTexts.Length; i++) {
            optionTexts[i] = node.options[i].text;
        }
        updateTexts(node.text, optionTexts);
        changeOptionsVisibility(optionTexts.Length);

        //callbacks
        node.OnDialogueNodeActivated(this);
    }

    public void selectOption(int index) {
        loadDialogueNode(currentDialogueNode.options[index].nextNode);
    }

    public void updateTexts(string npcText, string[] optionTexts) {
        npcTextMesh.text = applyColors(npcText);
        for (int i = 0; i < optionTexts.Length; i++) {
            optionTextMeshes[i].text = applyColors(optionTexts[i]);
        }
        changeOptionsVisibility(optionTexts.Length);
    }

    private string applyColors(string text) {
        foreach (NameColorPair nc in colors.colors) {
            text = text.Replace($"<{nc.name}>", $"<color=#{ColorUtility.ToHtmlStringRGBA(nc.color)}>");
            text = text.Replace($"</{nc.name}>", "</color>");
        }
        return text;
    }

    private void changeOptionsVisibility(int numberOfOptions) {
        for (int i = 0; i < optionTextMeshes.Length; i++) {
            optionTextMeshes[i].transform.parent.gameObject.SetActive(i < numberOfOptions);
        }
    }
}
