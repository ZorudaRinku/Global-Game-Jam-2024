using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurderWife : QuestStep
{
    private void OnEnable()
    {
        GameEventsManager.Instance.entityEvents.OnEntityKilled += OnKilledEntity;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.entityEvents.OnEntityKilled -= OnKilledEntity;
    }
    
    private void OnKilledEntity(string entityName)
    {
        if (entityName != "Wife") return;
        FinishQuestStep();
    }
}