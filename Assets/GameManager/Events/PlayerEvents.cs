using System;

public class PlayerEvents
{
    public event Action<int> OnPlayerLevelChanged;
    public void PlayerLevelChanged(int level)
    {
        OnPlayerLevelChanged?.Invoke(level);
    }
    
    public event Action<int> OnPlayerHealthChanged; // Set health
    public void PlayerHealthChanged(int health)
    {
        OnPlayerHealthChanged?.Invoke(health);
    }
    
    public event Action<int> OnPlayerHealthGained; // Add health
    public void PlayerHealthGained(int health)
    {
        OnPlayerHealthGained?.Invoke(health);
    }
    
    public event Action<int> OnPlayerExperienceChanged; // Set experience
    public void PlayerExperienceChanged(int experience)
    {
        OnPlayerExperienceChanged?.Invoke(experience);
    }
    
    public event Action<int> OnPlayerExperienceGained; // Add experience
    public void PlayerExperienceGained(int experience)
    {
        OnPlayerExperienceGained?.Invoke(experience);
    }
    
    public event Action OnPlayerDied; // Add experience
    public void PlayerDied()
    {
        OnPlayerDied?.Invoke();
    }
}