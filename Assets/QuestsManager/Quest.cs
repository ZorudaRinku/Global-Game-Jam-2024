using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public QuestInfoSO info;

    public QuestState state;

    private int currentQuestStepIndex;
    
    public Quest(QuestInfoSO info)
    {
        this.info = info;
        this.state = QuestState.REQUIREMENTS_NOT_MET;
        currentQuestStepIndex = 0;
    }
    
    public void MoveToNextQuestStep()
    {
        currentQuestStepIndex++;
        if (currentQuestStepIndex >= info.questStepPrefabs.Length)
        {
            state = QuestState.CAN_FINISH;
        }
    }

    public bool CurrentStepExists()
    {
        return currentQuestStepIndex < info.questStepPrefabs.Length;
    }

    public void InstantiateCurrentQuestStep(Transform parentTransform)
    {
        GameObject questStepPrefab = GetCurrentQuestStepPrefab();
        if (questStepPrefab != null)
        {
            GameObject questStep = GameObject.Instantiate(questStepPrefab, parentTransform);
            questStep.GetComponent<QuestStep>().InitializeQuestStep(info.id);
        }
    }
    
    private GameObject GetCurrentQuestStepPrefab()
    {
        GameObject questStepPrefab = null;
        if (CurrentStepExists())
        {
            questStepPrefab = info.questStepPrefabs[currentQuestStepIndex];
        }
        else
        {
            Debug.LogWarning("Tried to get quest step prefab, but it doesn't exist! QuestId=" + info.id + ", stepIndex=" + currentQuestStepIndex);
        }

        return questStepPrefab;
    }
}
