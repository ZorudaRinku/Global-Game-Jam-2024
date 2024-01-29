using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonderOnBridge : QuestStep
{
    private void OnEnable()
    {
        GameEventsManager.Instance.miscEvents.OnInteract += TalkedTo;
    }

    private void OnDisable()
    {
        AssetBundle.UnloadAllAssetBundles(true);
        GameEventsManager.Instance.miscEvents.OnInteract -= TalkedTo;
    }
    
    private void TalkedTo(EntityType type, string name)
    {
        if (type != EntityType.QuestItem || name != "Bridge") return;
        DialogueManager.Instance.initiateDialogue("...", Resources.Load<DialogueAsset>("Dialogue/Bridge/PonderOverBridge"));
        FinishQuestStep();
    }
}
