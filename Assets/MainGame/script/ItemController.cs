using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;
    [SerializeField] Dialog dialog;
    [SerializeField]
    DialogManager dialogueManager;
    [SerializeField]
    GameNovel gameNovel;

    public List<Dialogue> dialogue;

    public void Interact()
    {
        dialogueManager.lines.Clear();
        foreach(string dialogues in dialog.lines)
        {
            dialogueManager.lines.Add(dialogues);
            dialogueManager.write = true;
        }
        if(dialogueManager.thereIsNovel == false)
        {
            DialogManager.Instance.ShowDialog();
        }
        else
        {
            gameNovel.StartReadDialogue();
        }
    }
}
