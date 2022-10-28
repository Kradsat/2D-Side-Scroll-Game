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

    public event Action OnshowDialog;
    public event Action OnCloseDialog;

   public bool isTyping;

    public static DialogManager Instance
    {
        get; private set;
    }

    private void Awake()
    {
        Instance = this;
    }

  
    int currentLine = 0;
    public void ShowDialog(Dialog dialog)
    {
        dialogBox.SetActive(true);
     // StartCoroutine(typeDialog(dialog.Lines[0]));


        if (Input.GetKeyDown(KeyCode.Z) && !isTyping)
        {
                ++currentLine;
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(typeDialog(dialog.Lines[currentLine]));
            }
        }
        else
        {

            currentLine = 0;
            dialogBox.SetActive(false);
            //OnCloseDialog?.Invoke();
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
        isTyping = false;
        
    }
   
    
}
