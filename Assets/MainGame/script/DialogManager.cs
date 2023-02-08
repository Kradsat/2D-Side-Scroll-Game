using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject noItemDialogBox;
    [SerializeField] TMP_Text noItemDialogText;

    [SerializeField]
    GameObject getItemDialogue;
    [SerializeField]
    public Image itemImage;
    [SerializeField]
    TMP_Text getItemText;
    [SerializeField]
    public Item item;

    [SerializeField] int lettersPerSeconds;

    [SerializeField]
    GameObject nextArrow;
    [SerializeField]
    GameObject gameObject;
    [SerializeField]
    Charactercontroller characterController;
    [SerializeField]
    FlowScript flowScript;

    public event Action OnshowDialog;
    public event Action OnCloseDialog;

    public bool isTyping;

    public List<string> lines;
    public bool write = false;

    public bool dialogueShow = false;
    public bool thereIsItem = false;

    public bool thereIsNovel = false;

    public static DialogManager Instance
    {
        get; private set;
    }

    private void Awake()
    {
        Instance = this;
    }

  
    int currentLine = 0;
    public void ShowDialog()
    {
        nextArrow.SetActive(false);
        if(thereIsItem == false)
        {
            noItemDialogBox.SetActive(true);
        }
        else if(thereIsItem == true && item != null)
        {
            getItemDialogue.SetActive(true);
        }
        else if(thereIsItem == true && item == null)
        {
            currentLine = 0;
            characterController.stillWalking = true;
            flowScript.flow++;
        }
        
        if (write == true && !isTyping)
        {
            if (currentLine < lines.Count )
            {
                StartCoroutine(typeDialog(lines[currentLine]));
                dialogueShow = true;
                ++currentLine;
            }
            else
            {
                dialogueShow = false;
                CloseDialogue();
            }
        }
    }

    public IEnumerator typeDialog(string line)
    {
        isTyping = true;
        noItemDialogText.text = "";
        getItemText.text = "";
        foreach(var letter in line.ToCharArray())
        {
            noItemDialogText.text += letter;
            getItemText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSeconds);
        }
        nextArrow.SetActive(true);
        isTyping = false;
        yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Z));
        ShowDialog();
    }

    public void CloseDialogue()
    {
        currentLine = 0;
        noItemDialogBox.SetActive(false);
        getItemDialogue.SetActive(false);
        if(thereIsItem == true && item != null)
        {
            InventoryManager.Instance.Add(item);
            InventoryManager.Instance.ListOfItems();       
            flowScript.flow++;
 
        }
        else if(thereIsItem == true && item == null)
        {
            flowScript.flow++;
        }
        characterController.stillWalking = true;
    }   
}
