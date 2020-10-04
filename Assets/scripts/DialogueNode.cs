using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Wormius/DialogueNode", order = 0)]
public class DialogueNode : ScriptableObject {
    public string text;
    public DialogueOption[] options;
}

[System.Serializable]
public class DialogueOption {
    public string text;
    public DialogueNode nextNode;
}