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
        GameEventsManager.Instance.miscEvents.NpcInteract += SubmitPressed;
    }
    
    private void OnDisable()
    {
        GameEventsManager.Instance.questEvents.OnQuestStateChange -= OnQuestStateChange;
        GameEventsManager.Instance.miscEvents.NpcInteract -= SubmitPressed;
    }

    private void SubmitPressed(string npcName)
    {
        if (npcName != gameObject.name) return;
        
        switch (currentQuestState)
        {
            case QuestState.REQUIREMENTS_NOT_MET:
                // TODO: Create "requirements not met" dialogue event
                break;
            case QuestState.CAN_START when startPoint:
                DialogueManager.Instance.initiateDialogue(npcName, questInfoForPoint.startDialogue);
                GameEventsManager.Instance.questEvents.StartQuest(questId);
                break;
            case QuestState.CAN_FINISH when endPoint:
                DialogueManager.Instance.initiateDialogue(npcName, questInfoForPoint.finishDialogue);
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
