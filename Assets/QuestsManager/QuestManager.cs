using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private Dictionary<string, Quest> questMap;
    
    private int currentPlayerLevel;
    
    private void Awake()
    {
        questMap = CreateQuestMap();
    }
    
    private void OnEnable()
    {
        GameEventsManager.Instance.questEvents.OnStartQuest += StartQuest;
        GameEventsManager.Instance.questEvents.OnAdvanceQuest += AdvanceQuest;
        GameEventsManager.Instance.questEvents.OnFinishQuest += FinishQuest;
        
        GameEventsManager.Instance.playerEvents.OnPlayerLevelChanged += OnPlayerLevelChanged;
    }
    
    private void OnDisable()
    {
        GameEventsManager.Instance.questEvents.OnStartQuest -= StartQuest;
        GameEventsManager.Instance.questEvents.OnAdvanceQuest -= AdvanceQuest;
        GameEventsManager.Instance.questEvents.OnFinishQuest -= FinishQuest;
        
        GameEventsManager.Instance.playerEvents.OnPlayerLevelChanged -= OnPlayerLevelChanged;
    }

    private void Start()
    {
        foreach (var quest in questMap.Values)
        {
            GameEventsManager.Instance.questEvents.QuestStateChange(quest);
        }
    }

    private void Update()
    {
        foreach (var quest in questMap.Values)
        {
            if (quest.state == QuestState.REQUIREMENTS_NOT_MET && CheckRequirementsMet(quest))
            {
                ChangeQuestState(quest.info.id, QuestState.CAN_START);
            }
        }
    }

    private void ChangeQuestState(string id, QuestState newState)
    {
        Quest quest = GetQuestById(id);
        if (quest == null) return;
        
        quest.state = newState;
        GameEventsManager.Instance.questEvents.QuestStateChange(quest);
    }
    
    private void OnPlayerLevelChanged(int level)
    {
        currentPlayerLevel = level;
    }

    private bool CheckRequirementsMet(Quest quest)
    {
        bool requirementsMet = quest.info.levelRequirement <= currentPlayerLevel;

        foreach (var questPrerequisite in quest.info.questPrerequisites)
        {
            if (GetQuestById(questPrerequisite.id).state != QuestState.FINISHED)
            {
                requirementsMet = false;
            }
        }

        return requirementsMet;
    }

    private void StartQuest(string id)
    {
        Quest quest = GetQuestById(id);
        quest.InstantiateCurrentQuestStep(this.transform);
        ChangeQuestState(id, QuestState.IN_PROGRESS);
    }
    
    private void AdvanceQuest(string id)
    {
        Quest quest = GetQuestById(id);
        
        quest.MoveToNextQuestStep();
        
        if(quest.CurrentStepExists())
        {
            quest.InstantiateCurrentQuestStep(this.transform);
        }
        else
        {
            ChangeQuestState(id, QuestState.CAN_FINISH);
        }
    }
    
    private void FinishQuest(string id)
    {
        Quest quest = GetQuestById(id);
        ClaimRewards(quest);
        ChangeQuestState(quest.info.id, QuestState.FINISHED);
    }

    private void ClaimRewards(Quest quest)
    {
        GameEventsManager.Instance.playerEvents.PlayerExperienceGained(quest.info.experienceReward);
    }

    private Dictionary<string, Quest> CreateQuestMap()
    {
        // Loads all QuestInfoSO scriptable objects from the Resources/Quests folder
        QuestInfoSO[] questInfoSOs = Resources.LoadAll<QuestInfoSO>("Quests");
        
        // Create quest map
        Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>();
        foreach (QuestInfoSO questInfo in questInfoSOs)
        {
            if (idToQuestMap.ContainsKey(questInfo.id))
            {
                Debug.LogWarning("Quest with id " + questInfo.id + " already exists!");
            }
            Quest quest = new Quest(questInfo);
            idToQuestMap.Add(questInfo.id, quest);
        }

        return idToQuestMap;
    }

    private Quest GetQuestById(string id)
    {
        Quest quest = questMap[id];
        if (quest == null)
        {
            Debug.LogWarning("Quest with id " + id + " doesn't exist!");
        }

        return quest;
    }
    
    
}
