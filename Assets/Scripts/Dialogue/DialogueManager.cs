using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // initialization phase
    public DialogueAsset dialogue;
    [SerializeField] float textSpeed;
    [SerializeField] Canvas dialogueBox;
    public TextMeshProUGUI textComponent;
    private int currentIndex;
    private float time;
    private int charIndex;
    private char[] charArray;

    public static DialogueManager Instance { get; private set; }

    // contructs singleton
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    } // Awake

    // called on initialization
    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        prepareDialogue();
        hideDialogue();
    } // Start

    // runs every time script is set active
    private void OnEnable()
    {
        prepareDialogue();
    } // OnEnable

    // called once per frame
    private void Update()
    {
        
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {

            currentIndex++;
            if (currentIndex < dialogue.lines.Length)
            {
                proceedNextLine();
            }
            else
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
        textComponent.text = string.Empty;
        dialogueBox.gameObject.SetActive(false);
    } // hideDialogue

    // moves current dialogue to next line
    private void proceedNextLine()
    {
        textComponent.text = string.Empty;
        resetCharArray();
    } // proceedNextLine

    // resets char array for text scroll
    private void resetCharArray()
    {
        charArray = dialogue.lines[currentIndex].ToCharArray();
        charIndex = 0;
    } // resetCharArray

    // resets reused variables and prepares text field
    private void prepareDialogue()
    {
        textComponent.text = string.Empty;
        currentIndex = dialogue.startIndex;
        resetCharArray();
    } // prepareDialogue

    // activates and deactivates the dialogueBox
    public void SetActive(bool active)
    {
        dialogueBox.gameObject.SetActive(active);
    } // SetActive


} // DialogueManager