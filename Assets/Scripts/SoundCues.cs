using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCues : MonoBehaviour
{
    private void OnEnable()
    {
        GameEventsManager.Instance.playerEvents.OnPlayerExperienceGained += Getexp;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Getexp(int amount)
    {
        AudioManager.instance.PlaySFX("EXPGet");
    }
}
