using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ReadText : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;

    private Queue<string> names;
    private Queue<string> sentences;
    private Queue<string> expression;
    private Queue<string> soundEffect;
    private Queue<string> screenEffect;
    private Queue<string> back;

    public TextAsset textAsset;

    [SerializeField]
    LogButton logButton;

    [SerializeField]
    CharacterChangeScript characterChange;
    [SerializeField]
    BackgroundChangeScript backgroundChange;
    [SerializeField]
    SoundEffectScript soundEffectScript;
    [SerializeField]
    WriteDialogue writeDialogue;
    [SerializeField]
    ScreenEffectScript screenEffectScript;
    
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
        soundEffect = new Queue<string>();
        screenEffect = new Queue<string>();
        back = new Queue<string>();
        dialogue = new List<Dialogue>();

        GetData();
        StartDialogue();
    }

    void GetData()
    {
        Scene sceneName = SceneManager.GetActiveScene();
        data = textAsset.text.Split(new char[]{'\n'});
        if(sceneName.name == "Novel")
        {
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
        else if(sceneName.name == "Last")
        {
            for(int i = 1; i < data.Length - 1; i++)
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
    }
    
    public void StartDialogue()
    {
        sentences.Clear();
        names.Clear();
        expression.Clear();
        soundEffect.Clear();
        screenEffect.Clear();
        back.Clear();
        foreach (Dialogue d in dialogue.ToArray())
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

    public void DisplayNextSentence()
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

        backgroundChange.BackgroundChange(bg);
        soundEffectScript.PlaySoundEffect(se);

        if(screenEffectScript.isFading == true)//fade animation
        {
            charaCount = 0;
            StartCoroutine(FadeTextDelay(name, sentence, express));
        }
        else//usual text show
        {
            StartCoroutine(writeDialogue.WriteText(sentence));
            nameText.text = name;
            logButton.AddLog(sentence, lineCount, express);
        }

        screenEffectScript.ScreenEffect(screen);

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

    public IEnumerator FadeTextDelay(string name, string sentence, string express)
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(writeDialogue.WriteText(sentence));
        nameText.text = name;
        logButton.AddLog(sentence, lineCount, express);
    }

    public void EndDialogue()
    {
        Scene sceneName = SceneManager.GetActiveScene();
        if(sceneName.name == "Novel")
        {
            SceneManager.LoadScene(2);
        }
        else if(sceneName.name == "Last")
        {
            SceneManager.LoadScene("Title");
        }
    }
}
