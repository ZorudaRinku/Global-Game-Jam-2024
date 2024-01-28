using System;
using UnityEngine;

public class MiscEvents
{
    public event Action<string> NpcInteract;
    public void NpcInteracted(string npcName)
    {
        NpcInteract?.Invoke(npcName);
    }

    public event Action<String> KilledNpc;
    public void NpcKilled(string npcName)
    {
        KilledNpc?.Invoke(npcName);
    }
}