using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// creates menu option
[CreateAssetMenu()]
public class Dialogue : ScriptableObject
{
    // custom properties
    [TextArea]
    public string[] dialogueLines;
}
