using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToHarvey : QuestStep
{
    public DialogueAsset questStartDialogue;

    private void OnEnable()
    {
        GameEventsManager.Instance.miscEvents.OnInteract += TalkedTo;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.miscEvents.OnInteract -= TalkedTo;
    }
    
    private void TalkedTo(EntityType type, string name)
    {
        if (type != EntityType.NPC || name != "Harvey") return;
        DialogueManager.Instance.initiateDialogue(name, questStartDialogue);
        FinishQuestStep();
    }
}
