using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Wormius/DialogueNode", order = 0)]
public class DialogueNode : ScriptableObject {
    public string text;
    public DialogueOption[] options;

    public string[] onNodeActivatedEventsTrigerred;

    public void OnDialogueNodeActivated(DialogueUI uiInstance)
    {
        if(uiInstance == null)
        {
            Debug.LogError("The node activation callback may only be called by an active UI instance!");
            return;
        }

        foreach(var s in onNodeActivatedEventsTrigerred)
        {
            CustomEventManager.ActivateOnNodeActivatedEvent(s);
        }
        

    }

}

[System.Serializable]
public class DialogueOption {
    public string text;
    public DialogueNode nextNode;
}