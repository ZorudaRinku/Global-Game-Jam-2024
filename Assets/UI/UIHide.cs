using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHide : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(!DialogueManager.Instance.inConversation);
    }
}
