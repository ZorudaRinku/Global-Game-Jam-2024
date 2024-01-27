using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager Instance { get; private set; }

    public PlayerEvents playerEvents;
    public QuestEvents questEvents;
    public MiscEvents miscEvents;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("GameEventsManager already exists!");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        playerEvents = new PlayerEvents();
        questEvents = new QuestEvents();
        miscEvents = new MiscEvents();
    }
}