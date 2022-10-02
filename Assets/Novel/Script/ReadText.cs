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
    private Queue<string> expression;
    private Queue<string> back;

    public TextAsset textAsset;

    [SerializeField]
    LogButton logButton;

    [SerializeField]
    CharacterChangeScript characterChange;
    [SerializeField]
    BackgroundChangeScript backgroundChange;

    string[] data;
    string[] row;
    Dialogue d;

    int lineCount;
    int charaCount;

    string charaLeft;
    string charaRight;

    public List<Dialogue> dialogue;

    // Start is called before the first frame update
    void Start()
    {
        lineCount = 0;
        charaCount = 0;
        charaLeft = "";
        charaRight = "";

        sentences = new Queue<string>();
        names = new Queue<string>();
        expression = new Queue<string>();
        back = new Queue<string>();
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
        expression.Clear();
        back.Clear();
        foreach (Dialogue d in dialogue.ToArray())
        {
            names.Enqueue(d.name);
            sentences.Enqueue(d.sentences);
            expression.Enqueue(d.ui);
            back.Enqueue(d.background);
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
        string sentence = sentences.Dequeue();
        string express = expression.Dequeue();
        string bg = back.Dequeue();

        nameText.text = name;
        dialogueText.text = sentence;

        logButton.AddLog(sentence, lineCount, express);

        backgroundChange.BackgroundChange(bg);

        if(express != "")
        {
            if(charaLeft != express.Substring(0,1) && charaRight != express.Substring(0,1))
            {
                if(charaCount % 2 == 0)
                {
                    charaLeft = express.Substring(0,1);
                }
                else
                {
                    charaRight = express.Substring(0,1);
                }
                characterChange.CharacterChange(express, charaCount);
                charaCount++;
            }
        }
        lineCount++;
    }

    void EndDialogue()
    {

    }
}
