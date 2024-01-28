using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private int startingLevel = 1;
    [SerializeField] private int startingExperience;
    [SerializeField] private int startingHealth = 100;

    private int currentLevel;
    private int currentExperience;
    private int currentHealth;

    private void Awake()
    {
        currentLevel = startingLevel;
        currentExperience = startingExperience;
        currentHealth = startingHealth;
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.playerEvents.OnPlayerExperienceGained += ExperienceGained;
        GameEventsManager.Instance.playerEvents.OnPlayerHealthGained += HealthGained;
    }

    private void OnDisable() 
    {
        GameEventsManager.Instance.playerEvents.OnPlayerExperienceGained -= ExperienceGained;
        GameEventsManager.Instance.playerEvents.OnPlayerHealthGained -= HealthGained;
    }

    private void Start()
    {
        GameEventsManager.Instance.playerEvents.PlayerLevelChanged(currentLevel);
        GameEventsManager.Instance.playerEvents.PlayerExperienceChanged(currentExperience);
        GameEventsManager.Instance.playerEvents.PlayerHealthChanged(currentHealth);
    }

    private void HealthGained(int health)
    {
        currentHealth += health;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // TODO: Death screen
            Debug.Log("You Died");
            GameEventsManager.Instance.playerEvents.PlayerDied();
        }
        if (currentHealth >= 100) // Cap player health at 100
        {
            currentHealth = 100;
        }
    }

    private void ExperienceGained(int experience) 
    {
        currentExperience += experience;

        switch (currentExperience)
        {
            case >= 100:
                currentExperience -= 100;
                currentLevel++;
                GameEventsManager.Instance.playerEvents.PlayerLevelChanged(currentLevel);
                break;
            case <= 0:
                currentExperience += 100;
                currentLevel--;
                GameEventsManager.Instance.playerEvents.PlayerLevelChanged(currentLevel);
                break;
        }
        GameEventsManager.Instance.playerEvents.PlayerExperienceChanged(currentExperience);
    }

}
