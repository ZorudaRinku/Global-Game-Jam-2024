using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEXPUpdate : MonoBehaviour
{
    private Image image;
    
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        GameEventsManager.Instance.playerEvents.OnPlayerExperienceChanged += PlayerExperienceChanged;
    }

    private void PlayerExperienceChanged(int obj)
    {
        image.fillAmount = (float) obj / 100;
    }
}
