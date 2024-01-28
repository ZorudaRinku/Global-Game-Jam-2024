using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILevelUpdate : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        GameEventsManager.Instance.playerEvents.OnPlayerLevelChanged += PlayerLevelChanged;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.playerEvents.OnPlayerLevelChanged -= PlayerLevelChanged;
    }

    private void PlayerLevelChanged(int obj)
    {
        _textMeshPro.text = obj.ToString();
    }
}