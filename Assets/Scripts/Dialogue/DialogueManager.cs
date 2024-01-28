using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    // initialization phase
    public DialogueAsset dialogue;
    [SerializeField] float textSpeed;
    [SerializeField] Canvas dialogueBox;
    [SerializeField] Button buttonYes;
    [SerializeField] Button buttonNo;
    public TextMeshProUGUI textComponent;
    private int currentIndex;
    private float time;
    private int charIndex;
    private char[] charArray;
    private bool yesSelected;
    public bool inConversation;

    public static DialogueManager Instance { get; private set; }

    // contructs singleton
    private void Awake()
    {
        if (Instance != null && Instance != this)
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
        prepareDialogue(true);
        hideDialogue();
    } // Start

    // runs every time script is set active
    private void OnEnable()
    {
        prepareDialogue(true);
        inConversation = true;
    } // OnEnable

    // called once per frame
    private void Update()
    {
        
        time += Time.deltaTime;

        // check if player needs to answer request. if not, proceed to next line. if so, loop prompt until yes selected
        if ((Input.GetKeyDown(KeyCode.Space) && !dialogue.lineRequiresReply[currentIndex]) || yesSelected)
        {

            currentIndex++;

            if (yesSelected)
            {
                yesSelected = false;
            }

            if (currentIndex < dialogue.lines.Length)
            {
                proceedNextLine();
            }
            else
            {
               hideDialogue();
            }

        } else if (Input.GetKeyDown(KeyCode.Space) && dialogue.lineRequiresReply[currentIndex] && !yesSelected)
        {
            replyToLine();
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
        inConversation = false;
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

    // resets reused variables and prepares text field. resetLines is ran on enable, but never ran after that
    private void prepareDialogue(bool resetLines)
    {
        textComponent.text = string.Empty;
        if (resetLines)
        {
            hideButtons();
            currentIndex = dialogue.startIndex;
            yesSelected = false;
        }
        
        resetCharArray();
    } // prepareDialogue

    // activates and deactivates the dialogueBox
    public void SetActive(bool active)
    {
        dialogueBox.gameObject.SetActive(active);
    } // SetActive

    // activates buttons for interaction
    private void replyToLine()
    {
        showButtons();
        yesSelected = false;
    } // replyToLine

    // proceeds dialogue
    public void yesButtonClicked()
    {
        yesSelected = true;
        hideButtons();
    } // yesButtonClicked

    // replays the last line of dialogue
    public void noButtonClicked()
    {
        prepareDialogue(false);
        showDialogue(dialogue.lines[currentIndex]);
    } // noButtonClicked

    // use your imagination on this one
    private void showButtons()
    {
        buttonYes.gameObject.SetActive(true);
        buttonNo.gameObject.SetActive(true);
    } // showButtons

    // im sure you can figure this one out
    private void hideButtons()
    {
        buttonYes.gameObject.SetActive(false);
        buttonNo.gameObject.SetActive(false);
    } // hideButtons

} // DialogueManager