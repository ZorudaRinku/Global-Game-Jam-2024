using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] DialogueAsset dialogue;
    public dialogueManager managerObject;

    private void Start()
    {
        managerObject = FindFirstObjectByType<dialogueManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Colliding with player");
        managerObject.dialogue = dialogue;
    } // OnTriggerEnter2D
    
} // NPCDialogue
