using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Auto : MonoBehaviour
{
    [SerializeField]
    Button autoButton;
    [SerializeField]
    Image iconImage;
    [SerializeField]
    Sprite[] spriteUI;

    [SerializeField]
    ReadText readText;
    [SerializeField]
    WriteDialogue writeDialogue;

    public bool autoOn;

    // Start is called before the first frame update
    void Start()
    {
        autoOn = false;
        autoButton.onClick.AddListener(autoButtonPress);
    }

    void autoButtonPress()
    {
        if(autoOn == false)
        {
            iconImage.sprite = spriteUI[1];
            autoOn = true;

            if(writeDialogue.sentenceComplete == true)
            {
                readText.DisplayNextSentence();
            }
        }
        else
        {
            iconImage.sprite = spriteUI[0];
            autoOn = false;
        }
    }
}
