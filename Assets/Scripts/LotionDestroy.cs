using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotionDestroy : MonoBehaviour
{
    private bool _questInProgress = false;
    private void OnEnable()
    {
        GameEventsManager.Instance.miscEvents.NpcInteract += OnTalkedToNPC;
        GameEventsManager.Instance.questEvents.OnStartQuest += OnStartQuest;
    }

    private void OnStartQuest(string obj)
    {
        if (obj == "FetchLotion")
        {
            _questInProgress = true;
        }
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.miscEvents.NpcInteract -= OnTalkedToNPC;
    }
    
    private void OnTalkedToNPC(string npcName)
    {
        if (npcName == "Holy Oil" && _questInProgress)
        {
            Destroy(gameObject);
        }
    }
}
