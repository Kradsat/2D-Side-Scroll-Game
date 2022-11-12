using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] int lettersPerSeconds;

    [SerializeField]
    GameObject nextArrow;

    public event Action OnshowDialog;
    public event Action OnCloseDialog;

    public bool isTyping;

    public List<string> lines;
    public bool write = false;

    public bool dialogueShow = false;

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
        dialogBox.SetActive(true);
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
                //OnCloseDialog?.Invoke();
                dialogueShow = false;
                CloseDialogue();
            }
        }
    }

    public IEnumerator typeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach(var letter in line.ToCharArray())
        {
            dialogText.text += letter;
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
            dialogBox.SetActive(false);
    }   
}
