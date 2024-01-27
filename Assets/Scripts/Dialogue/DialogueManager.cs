using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueManager : MonoBehaviour
{
    // initialization phase
    [SerializeField] DialogueAsset dialogue;
    [SerializeField] float textSpeed;
    [SerializeField] Canvas dialogueBox;
    public TextMeshProUGUI textComponent;
    private int currentIndex;
    private float time;
    private int charIndex;
    private char[] charArray;

    // called on initialization
    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = string.Empty;
        currentIndex = dialogue.startIndex;
        resetCharArray();
    } // Start

    // called once per frame
    private void Update()
    {
        
        time += Time.deltaTime;

        // proceed key, end if on last index item
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentIndex++;
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

        dialogueBox.gameObject.SetActive(true);

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
        dialogueBox.gameObject.SetActive(false);
        textComponent.text = string.Empty; ;
    } // hideDialogue

    // moves current dialogue to next line
    private void proceedNextLine()
    {
        //currentIndex++;
        textComponent.text = string.Empty;
        resetCharArray();
    } // proceedNextLine

    // resets char array for text scroll
    private void resetCharArray()
    {
        charArray = dialogue.lines[currentIndex].ToCharArray();
        charIndex = 0;
    } // resetCharArray

} // DialogueManager