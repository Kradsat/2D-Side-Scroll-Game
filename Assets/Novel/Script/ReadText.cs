using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReadText : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;

    public Button nextDialogueButton;

    private Queue<string> names;
    private Queue<string> sentences;

    public TextAsset textAsset;

    [SerializeField]
    LogButton logButton;

    string[] data;
    string[] row;
    Dialogue d;

    public List<Dialogue> dialogue;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        dialogue = new List<Dialogue>();
        nextDialogueButton.onClick.AddListener(DisplayNextSentence);

        GetData();
        StartDialogue();
    }

    void GetData()
    {
        data = textAsset.text.Split(new char[]{'\n'});
        for(int i = 1; i < data.Length; i++)
        {
            d = new Dialogue();
            row = data[i].Split(new char[] { ',' });
            int.TryParse(row[0], out d.number);
            d.name = row[1];
            d.sentences = row[2];
            d.ui = row[3];
            d.se = row[4];
            d.bgm = row[5];
            d.item = row[6]; 
            d.animation = row[7];
            d.effect = row[8];
            d.background = row[9];

            dialogue.Add(d);
        }
    }
    
    public void StartDialogue()
    {
        sentences.Clear();
        names.Clear();
        foreach (Dialogue d in dialogue.ToArray())
        {
            names.Enqueue(d.name);
            sentences.Enqueue(d.sentences);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        nameText.text = string.Empty;
        dialogueText.text = string.Empty;
        
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string name = names.Dequeue();
        nameText.text = name;
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

        logButton.AddLog(sentence);
    }

    void EndDialogue()
    {

    }
}
