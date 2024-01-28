using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotionDestroy : MonoBehaviour
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
            Destroy(gameObject);
        }
    }
}
