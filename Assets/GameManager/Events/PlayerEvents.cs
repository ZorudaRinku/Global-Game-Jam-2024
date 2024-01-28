using System;

public class PlayerEvents
{
    private int playerLevel; // TODO: Connect to player methods, need to call OnPlayerLevelChange when we instantiate the player (In "OnReady")
    private int playerExperience; // TODO: Connect to player methods, need to call OnPlayerExperienceChange when we instantiate the player (In "OnReady")
    private int playerHealth = 100;
    
    public event Action<int> OnPlayerLevelChange;
    public void PlayerLevelChange(int level)
    {
        OnPlayerLevelChange?.Invoke(level);
    }
    
    public event Action<int> OnPlayerHealthChange;
    public void PlayerHealthChange(int health)
    {
        playerHealth += health;
        OnPlayerHealthChange?.Invoke(playerHealth);
    }
    
    public event Action<int> OnPlayerExperienceChange;
    public void PlayerExperienceChange(int experience)
    {
        playerExperience += experience;
        if (playerExperience >= 100)
        {
            playerExperience -= 100;
            playerLevel++;
            PlayerLevelChange(playerLevel);
        }
        OnPlayerExperienceChange?.Invoke(experience);
    }
}