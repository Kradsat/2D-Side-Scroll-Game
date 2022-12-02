using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameNovel : MonoBehaviour
{
    public TextAsset csv;

    [SerializeField]
    DialogManager dialogueManager;
    [SerializeField]
    FlowScript flowScript;

    [SerializeField]
    GameObject novel;
    [SerializeField]
    Button nextButton;
    [SerializeField]
    TMP_Text nameText;
    [SerializeField]
    TMP_Text dialogueText;
    [SerializeField]
    GameObject novelArrow;

    private Queue<string> names;
    private Queue<string> sentences;
    private Queue<string> expression;
    private Queue<string> soundEffect;
    private Queue<string> screenEffect;
    private Queue<string> back;

    string[] data;
    string[] row;
    Dialogue d;

    int lineCount;
    int charaCount;
    int dialogueSpeed;

    string charaLeft;
    string charaRight;

    bool sentenceComplete;

    public List<Dialogue> dialogueLine;

    void Start()
    {
        dialogueSpeed = 50;
        nextButton.onClick.AddListener(NextDialogueSentence);
    }

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return)) && dialogueManager.thereIsNovel == true)
        {
            NextDialogueSentence();
        }
    }

    public void StartReadDialogue()
    {
        lineCount = 0;
        charaCount = 0;
        charaLeft = "";
        charaRight = "";

        sentences = new Queue<string>();
        names = new Queue<string>();
        expression = new Queue<string>();
        soundEffect = new Queue<string>();
        screenEffect = new Queue<string>();
        back = new Queue<string>();
        dialogueLine = new List<Dialogue>();

        novel.SetActive(true);

        GetData();
        StartDialogue();
    }

    void GetData()
    {
        data = csv.text.Split(new char[]{'\n'});
        for(int i = 1; i < data.Length -1; i++)
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

            dialogueLine.Add(d);
        }
    }
    
    void StartDialogue()
    {
        sentences.Clear();
        names.Clear();
        expression.Clear();
        soundEffect.Clear();
        screenEffect.Clear();
        back.Clear();
        foreach (Dialogue d in dialogueLine.ToArray())
        {
            names.Enqueue(d.name);
            sentences.Enqueue(d.sentences);
            expression.Enqueue(d.ui);
            soundEffect.Enqueue(d.se);
            screenEffect.Enqueue(d.animation);
            back.Enqueue(d.background);
        }
        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
        StopAllCoroutines();
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
        string se = soundEffect.Dequeue();
        string screen = screenEffect.Dequeue();
        string bg = back.Dequeue();

        //soundEffectScript.PlaySoundEffect(se);

        charaCount = 0;
        //usual text show
        
        StartCoroutine(WriteDialogueText(sentence));
        nameText.text = name;
        

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
                //characterChange.CharacterChange(express, charaCount);
                charaCount++;
            }
        }
        lineCount++;
    }

    void EndDialogue()
    {
        novel.SetActive(false);
        dialogueManager.thereIsNovel = false;
        flowScript.flow++;
        dialogueManager.ShowDialog();
    }

    IEnumerator WriteDialogueText(string sentence)
    {
        float t = 0;
        int charIndex = 0;
        sentenceComplete = false;

        while (charIndex < sentence.Length && sentenceComplete == false)
        {
			t += Time.deltaTime * dialogueSpeed;
			charIndex = Mathf.FloorToInt(t);
			charIndex = Mathf.Clamp(charIndex, 0, sentence.Length);
            dialogueText.text = sentence.Substring(0, charIndex);

            yield return null;
        }

        sentenceComplete = true;
        dialogueText.text = sentence;
        novelArrow.SetActive(true);
    }

    void NextDialogueSentence()
    {
        if(sentenceComplete == true)
        {
            DisplayNextSentence();
        }
        else
        {
            sentenceComplete = true;
        }
    }
    
}
