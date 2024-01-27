using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDialogueInteract : MonoBehaviour
{
    [SerializeField] float talkDistance;
    private bool inConversation;

    private void Start()
    {
        inConversation = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !inConversation)
        {
            DialogueManager.Instance.SetActive(true);
            inConversation = true;
        }
        else
        {
            inConversation = false;
        }
    } // Update

} // PlayerDialogueInteract
