using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenEffectScript : MonoBehaviour
{
    [SerializeField]
    GameObject fadeActive;

    [SerializeField]
    ReadText readText;

    [SerializeField]
    Animator fadeAnimation;

    public bool isFading;

    void Start()
    {
        isFading = false;
    }

    public void ScreenEffect(string str)
    {
        if(str.Contains("暗転"))
        {
            isFading = true;
        }
    }

    public IEnumerator StartFadeAnimation()
    {
        fadeActive.SetActive(true);
        readText.dialogueText.text = string.Empty;
        readText.nameText.text = string.Empty;

        fadeAnimation.SetBool("Fade", true);
        yield return new WaitForSeconds(2f);
        
        readText.DisplayNextSentence();
        StartCoroutine(EndFadeAnimation());
    }

    public IEnumerator EndFadeAnimation()
    {
        fadeAnimation.SetBool("Fade", false);
        yield return new WaitForSeconds(1.5f);
        fadeActive.SetActive(false);
        isFading = false;
    }
}
