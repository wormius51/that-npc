using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueColors", menuName = "Wormius/DialogueColors", order = 0)]
public class DialogueColors : ScriptableObject {
    public NameColorPair[] colors;
}

[System.Serializable]
public class NameColorPair {
    public string name;
    public Color color = Color.white;
}