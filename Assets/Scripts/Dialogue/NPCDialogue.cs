using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] DialogueAsset dialogue;
    //public DialogueManager managerObject;

    /*private void Start()
    {
        managerObject = FindFirstObjectByType<DialogueManager>();
        Debug.Log(managerObject);
    }
    */

    private void Update()
    {
        /*
        if (managerObject == null)
        {
            managerObject = FindFirstObjectByType<DialogueManager>();
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if(managerObject!= null)
       // {
            //managerObject.dialogue = dialogue;
            DialogueManager.Instance.dialogue = dialogue;
       // }
        
    } // OnTriggerEnter2D
    
} // NPCDialogue
