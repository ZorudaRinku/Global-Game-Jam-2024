using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchLotion : QuestStep
{
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
        if (npcName == "Holy Oil")
        {
            DialogueAsset dialogue = Resources.Load<DialogueAsset>("Dialogue/HolyOil/GetLotion");
            FinishQuestStep();
        }
    }
}
