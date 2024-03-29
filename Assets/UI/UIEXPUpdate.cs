using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEXPUpdate : MonoBehaviour
{
    private Image image;
    private float currentFill;
    private int currnetLevel;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        image = GetComponent<Image>();
        GameEventsManager.Instance.playerEvents.OnPlayerLevelChanged += PlayerLevelChanged;
        GameEventsManager.Instance.playerEvents.OnPlayerExperienceChanged += PlayerExperienceChanged;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.playerEvents.OnPlayerLevelChanged -= PlayerLevelChanged;
        GameEventsManager.Instance.playerEvents.OnPlayerExperienceChanged -= PlayerExperienceChanged;
    }

    private void Update()
    {
        if (Math.Abs(image.fillAmount - currentFill) > 0.01)
        {
            image.fillAmount = Mathf.Lerp(image.fillAmount, currentFill, Time.deltaTime * 2);
        }
    }

    private void PlayerExperienceChanged(int obj)
    {
        currentFill = (float) obj / 100;
    }

    private void PlayerLevelChanged(int obj)
    {
        if (obj < currnetLevel)
        {
            image.fillAmount = 100;
        } else if (obj > currnetLevel)
        {
            image.fillAmount = 0;
        }
        currnetLevel = obj;
    }
}
