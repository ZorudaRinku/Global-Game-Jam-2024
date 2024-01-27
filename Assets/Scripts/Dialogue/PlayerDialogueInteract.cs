using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDialogueInteract : MonoBehaviour
{
    [SerializeField] float talkDistance;
    public GameObject DialogueManagerObject;
    private bool inConversation;
    // public UnityEvent inDialogue;

    private void Start()
    {
        //GameEvents.current.onEndDialogue += leaveConversation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !inConversation)
        {
            //interact();
            DialogueManagerObject.SetActive(true);
        }
    } // Update

    // starts dialogue with interacted NPC
    private void interact()
    {
        joinConversation();
    } // interact

    // manages dialogue state
    private void joinConversation()
    {
        inConversation = true;
       // GameEvents.current.dialogueStartTrigger();
    } // JoinConversation

    // managed dialogue state
    public void leaveConversation()
    {
        inConversation = false;
    } // LeaveConveration

} // PlayerDialogueInteract
