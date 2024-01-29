using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class QuestPoint : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] private QuestInfoSO questInfoForPoint;

    [Header("Config")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool endPoint = true;
    
    private string questId;
    
    private QuestState currentQuestState;

    private void Awake()
    {
        questId = questInfoForPoint.id;
    }
    
    private void OnEnable()
    {
            GameEventsManager.Instance.questEvents.OnQuestStateChange += OnQuestStateChange;
        GameEventsManager.Instance.miscEvents.OnInteract += SubmitPressed;
    }
    
    private void OnDisable()
    {
        GameEventsManager.Instance.questEvents.OnQuestStateChange -= OnQuestStateChange;
        GameEventsManager.Instance.miscEvents.OnInteract -= SubmitPressed;
    }

    private void SubmitPressed(EntityType type, string name)
    {
        if (name != gameObject.name) return;
        
        switch (currentQuestState)
        {
            case QuestState.REQUIREMENTS_NOT_MET:
                // TODO: Create "requirements not met" dialogue event
                break;
            case QuestState.CAN_START when startPoint:
                DialogueManager.Instance.initiateDialogue(name, questInfoForPoint.startDialogue);
                GameEventsManager.Instance.questEvents.StartQuest(questId);
                break;
            case QuestState.CAN_FINISH when endPoint:
                DialogueManager.Instance.initiateDialogue(name, questInfoForPoint.finishDialogue);
                GameEventsManager.Instance.questEvents.FinishQuest(questId);
                break;
        }
    }
    
    private void OnQuestStateChange(Quest quest)
    {
        if (quest.info.id != questId) return;
        currentQuestState = quest.state;
        Debug.Log("QuestPoint: " + questId + " is now " + currentQuestState);
    }
}
