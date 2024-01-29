using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private List<Collider2D> collidingTriggers = new List<Collider2D>();

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        // Create a temporary copy for enumeration
        var tempTriggers = new List<Collider2D>(collidingTriggers);
        // Process the list of colliding triggers
        foreach (var trigger in tempTriggers)
        {
            if (trigger.CompareTag("NPC"))
            {
                GameEventsManager.Instance.miscEvents.NpcInteracted(trigger.gameObject.name);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        collidingTriggers.Add(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        collidingTriggers.Remove(other);
    }
}