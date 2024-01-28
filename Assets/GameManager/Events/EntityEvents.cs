using System;
using UnityEngine;

public class EntityEvents
{
    public event Action<string> OnEntityHit;
    public void HitEntity(string entityName)
    {
        OnEntityHit?.Invoke(entityName);
    }

    public event Action<String> OnEntityKilled;
    public void KilledEntity(string entityName)
    {
        OnEntityKilled?.Invoke(entityName);
    }
}