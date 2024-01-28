using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouse : QuestStep
{
    private void OnEnable()
    {
        // TODO: Subscribe to player teleport event
    }

    private void OnDisable()
    {
        // TODO: Unsubscribe to player teleport event
    }
    
    private void TeleportToHouse(string entityName)
    {
        DialogueManager.Instance.initiateDialogue("Wife", Resources.Load<DialogueAsset>("Dialogue/Harvey's Wife/Harvey'sWifeQuest"));
        FinishQuestStep();
    }
}