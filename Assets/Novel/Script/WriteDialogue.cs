using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteDialogue : MonoBehaviour
{
    [SerializeField]
    ReadText readText;
    [SerializeField]
    Auto autoScript;
    [SerializeField]
    ScreenEffectScript screenEffect;

    [SerializeField]
    Button nextDialogueButton;

    int dialogueSpeed;

    public bool sentenceComplete;

    // Start is called before the first frame update
    void Start()
    {
        dialogueSpeed = 50;
        sentenceComplete = false;

        nextDialogueButton.onClick.AddListener(NextSentence);
    }

    // Update is called once per frame
    public IEnumerator WriteText(string sentence)
    {
        float t = 0;
        int charIndex = 0;
        sentenceComplete = false;

        while (charIndex < sentence.Length && sentenceComplete == false)
        {
			t += Time.deltaTime * dialogueSpeed;
			charIndex = Mathf.FloorToInt(t);
			charIndex = Mathf.Clamp(charIndex, 0, sentence.Length);
            readText.dialogueText.text = sentence.Substring(0, charIndex);

            yield return null;
        }

        readText.dialogueText.text = sentence;

        if(charIndex == sentence.Length)
        {
            sentenceComplete = true;
        }

        if(autoScript.autoOn == true && charIndex == sentence.Length)
        {
            yield return new WaitForSeconds(2);
            if(autoScript.autoOn == true && screenEffect.isFading == false)
            {
                readText.DisplayNextSentence();
            }
            else if(autoScript.autoOn == true && screenEffect.isFading == true)
            {
                StartCoroutine(screenEffect.StartFadeAnimation());
            }
        }    
    }

    void NextSentence()
    {
        if(sentenceComplete == false)
        {
            sentenceComplete = true;
        }
        else if(sentenceComplete == true && screenEffect.isFading == false)
        {
            readText.DisplayNextSentence();
        }
        else if(sentenceComplete == true && screenEffect.isFading == true)
        {
            StartCoroutine(screenEffect.StartFadeAnimation());
        }
    }
}
