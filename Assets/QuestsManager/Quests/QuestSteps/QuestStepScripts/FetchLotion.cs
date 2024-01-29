using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchLotion : QuestStep
{
    [SerializeField] private GameObject holyOilPrefab;
    private GameObject holyOil;
    private void OnEnable()
    {
        GameEventsManager.Instance.miscEvents.NpcInteract += OnTalkedToNPC;
        holyOil = Instantiate(holyOilPrefab);
        // holyOil.transform.position = new Vector3(0, 0, 0); Animation will handle this
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.miscEvents.NpcInteract -= OnTalkedToNPC;
    }
    
    private void OnTalkedToNPC(string npcName)
    {
        if (npcName == holyOil.name)
        {
            Destroy(holyOil);
            FinishQuestStep();
        }
    }
}
