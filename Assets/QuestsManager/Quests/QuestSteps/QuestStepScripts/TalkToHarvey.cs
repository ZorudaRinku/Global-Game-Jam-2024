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
        GameEventsManager.Instance.miscEvents.KilledNpc += OnKilledNPC;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.miscEvents.NpcInteract -= OnTalkedToNPC;
        GameEventsManager.Instance.miscEvents.KilledNpc -= OnKilledNPC;
    }
    
    private void OnTalkedToNPC(string npcName)
    {
        if (npcName == "Harvey Point")
        {
            DialogueManager.Instance.initiateDialogue("npcName", questStartDialogue);
            FinishQuestStep();
        }
    }
    
    private void OnKilledNPC(string npcName)
    {
        if (npcName == "Harvey")
        {
            // TODO: Punish?
            FinishQuestStep();
        }
    }
}
