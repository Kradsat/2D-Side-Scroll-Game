using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxComponent : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI boxText;

    public void GetText(string txt)
    {
        boxText.text = txt;
    }
}
