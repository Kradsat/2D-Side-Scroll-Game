using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipButton : MonoBehaviour
{
    [SerializeField]
    Button skipButton;

    [SerializeField]
    ReadText readText;
    // Start is called before the first frame update
    void Start()
    {
        skipButton.onClick.AddListener(readText.EndDialogue);
    }
}
