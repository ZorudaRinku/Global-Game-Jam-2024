using System;
using UnityEngine;

public class MiscEvents
{
    public event Action<EntityType, string> OnInteract;
    public void Interacted(EntityType type, string name)
    {
        OnInteract?.Invoke(type, name);
    }

    public event Action<String> KilledNpc;
    public void NpcKilled(string npcName)
    {
        KilledNpc?.Invoke(npcName);
    }
}