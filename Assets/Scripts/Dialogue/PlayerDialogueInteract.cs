using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueInteract : MonoBehaviour
{
    private bool inConversation;

    private void Start()
    {
        DialogueManager.Instance.inConversation = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !DialogueManager.Instance.inConversation)
        {
            DialogueManager.Instance.SetActive(true);
        }
    } // Update

} // PlayerDialogueInteract
