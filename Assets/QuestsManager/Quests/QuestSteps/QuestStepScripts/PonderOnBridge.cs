using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonderOnBridge : QuestStep
{
    private void OnEnable()
    {
        GameEventsManager.Instance.miscEvents.NpcInteract += OnTalkedToNPC;
    }

    private void OnDisable()
    {
        AssetBundle.UnloadAllAssetBundles(true);
        GameEventsManager.Instance.miscEvents.NpcInteract -= OnTalkedToNPC;
    }
    
    private void OnTalkedToNPC(string npcName)
    {
        if (npcName != "Bridge") return;
        DialogueManager.Instance.initiateDialogue("...", Resources.Load<DialogueAsset>("Dialogue/Bridge/PonderOverBridge"));
        FinishQuestStep();
    }
}
