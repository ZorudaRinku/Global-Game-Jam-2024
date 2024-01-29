using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToHarvey : QuestStep
{
    public DialogueAsset questStartDialogue;

    private void OnEnable()
    {
        GameEventsManager.Instance.miscEvents.NpcInteract += OnTalkedToNPC;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.miscEvents.NpcInteract -= OnTalkedToNPC;
    }
    
    private void OnTalkedToNPC(string npcName)
    {
        if (npcName != "Harvey") return;
        DialogueManager.Instance.initiateDialogue(npcName, questStartDialogue);
        FinishQuestStep();
    }
}
