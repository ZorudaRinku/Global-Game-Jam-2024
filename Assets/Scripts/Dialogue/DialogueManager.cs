using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueManager : MonoBehaviour
{
    [SerializeField] DialogueAsset dialogue;
    [SerializeField] float textSpeed;
    public TextMeshProUGUI textComponent;
    public int currentIndex;
    public float time;
    public int charIndex;
    char[] charArray;

    // called on initialization
    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = string.Empty;
        currentIndex = dialogue.startIndex;
        resetCharArray();
    } // Start

    // called once per frame
    private void FixedUpdate()
    {
        time += Time.deltaTime;

        // proceed key, end if on last index item
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentIndex < dialogue.lines.Length)
            {
                proceedNextLine();
            } else
            {
                hideDialogue();
            }
            
        }

        // stop displaying dialogue if no lines remaining
        if (currentIndex < dialogue.lines.Length)
        {
            showDialogue(dialogue.lines[currentIndex]);
        }

    } // Update

    // displays one line of dialogue to the screen
    private void showDialogue(string line)
    {
        
        if(time >= textSpeed && charIndex < charArray.Length)
        {
            textComponent.text += charArray[charIndex];
            charIndex++;
            time = 0.0f;
        }


    } // showDialogue

    // hides the dialogue display
    private void hideDialogue()
    {
        textComponent.text = null;
    } // hideDialogue

    // moves current dialogue to next line
    private void proceedNextLine()
    {
        currentIndex++;
        textComponent.text = string.Empty;
        resetCharArray();
    } // proceedNextLine

    // resets char array for text scroll
    private void resetCharArray()
    {
        charArray = dialogue.lines[currentIndex].ToCharArray();
        charIndex = 0;
    } // resetCharArray
} 