using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonderOnBridge : QuestStep
{
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
        if (npcName == "Bridge Point")
        {
            // TODO: Connect to DialogueManager
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
