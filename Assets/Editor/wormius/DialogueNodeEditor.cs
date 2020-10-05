using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DialogueNode))]
public class DialogueNodeEditor : Editor {
    public override void OnInspectorGUI() {
        EditorGUILayout.LabelField("NPC Text");
        DialogueNode node =  (DialogueNode)target;
        
        node.text = EditorGUILayout.TextArea(node.text, GUILayout.MinHeight(50), GUILayout.ExpandHeight(true));
        base.OnInspectorGUI();
        AssetDatabase.SaveAssets();
    }
}
