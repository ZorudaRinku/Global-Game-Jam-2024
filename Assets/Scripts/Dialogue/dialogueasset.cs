using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// creates menu option
[CreateAssetMenu()]
public class DialogueAsset : ScriptableObject
{
    // custom properties
    [TextArea]
    public string[] lines;
    public int startIndex = 0;
}