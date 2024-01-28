using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPUpdate : MonoBehaviour
{
    private Image image;
    
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        GameEventsManager.Instance.playerEvents.OnPlayerHealthChanged += PlayerHealthChanged;
    }

    private void PlayerHealthChanged(int obj)
    {
        image.fillAmount = (float) obj / 100;
    }
}