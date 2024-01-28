using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// creates menu option
[CreateAssetMenu()]
public class NPCScriptableObject : ScriptableObject
{
    // custom properties
    public DialogueAsset defaultLine;
    public string characterName;
    public Sprite characterSprite;
    public bool isAlive = true;
}
