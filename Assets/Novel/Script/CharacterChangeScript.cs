using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChangeScript : MonoBehaviour
{
    [SerializeField]
    Image leftCharacter;
    [SerializeField]
    Image rightCharacter;

    [SerializeField]
    Image leftExpression;
    [SerializeField]
    Image rightExpression;

    [SerializeField]
    Sprite[] characterUI;

    int count;

    public void CharacterChange(string character, int num)
    {
        Debug.Log(character);
        //character main UI
        if(character.Contains("K"))
        {
            count = 0;
        }
        else if(character.Contains("S"))
        {
            count = 1;
        }
        else if(character.Contains("A"))
        {
            count = 2;
        }
        else if(character.Contains("M"))
        {
            count = 3;
        }
        
        //left or right character change
        if(num % 2 == 0)
        {
            leftCharacter.color = new Color(255,255,255,255);
            leftCharacter.sprite = characterUI[count];
        }
        else
        {
            rightCharacter.color = new Color(255,255,255,255);
            rightCharacter.sprite = characterUI[count];
        }
    }
}
