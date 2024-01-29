using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurderBunnies : QuestStep
{
    private int _count;
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
        if (entityName != "Bunny") return;
        _count++;
        if (_count >= 5)
        {
            FinishQuestStep();
        }
    }
}