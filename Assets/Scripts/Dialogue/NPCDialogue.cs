using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] DialogueAsset dialogue;

    private void OnCollisionEnter2D(Collision2D other)
    {
        DialogueManager.Instance.dialogue = dialogue;
    } // OnTriggerEnter2D
    
} // NPCDialogue
