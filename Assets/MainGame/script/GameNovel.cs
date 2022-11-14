using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameNovel : MonoBehaviour
{
    public TextAsset csv;

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

    List<string> dialogueLine;

    void NovelStart()
    {
        
    }
}
