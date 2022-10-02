using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBoxComponent : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI boxText;
    [SerializeField]
    Image circleImage;

    [SerializeField]
    Sprite[] characterSprite;

    public void SetText(string txt)
    {
        boxText.text = txt;
    }

    public void SetImage(int num)
    {
        circleImage.sprite = characterSprite[num];
    }
}
