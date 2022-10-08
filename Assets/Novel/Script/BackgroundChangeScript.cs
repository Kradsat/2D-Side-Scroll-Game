using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChangeScript : MonoBehaviour
{
    [SerializeField]
    Image backGround;
    [SerializeField]
    Sprite[] backgroundSprite;

    public void BackgroundChange(string back)
    {
        if(back.Contains("廊下"))
        {
            backGround.sprite = backgroundSprite[0];
        }
        else if(back.Contains("教室"))
        {
            backGround.sprite = backgroundSprite[1];
        }    
    }
}
