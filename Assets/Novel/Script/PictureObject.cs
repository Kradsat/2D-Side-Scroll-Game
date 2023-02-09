using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureObject : MonoBehaviour
{
    [SerializeField]
    ReadText readText;

    [SerializeField]
    Button button;
    [SerializeField]
    GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(ButtonClick);
    }

    // Update is called once per frame
    void ButtonClick()
    {
        readText.DisplayNextSentence();
        readText.itemEffectScreen = false;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(gameObject.active == true && (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return)))
        {
            readText.DisplayNextSentence();
            readText.itemEffectScreen = false;
            gameObject.SetActive(false);
        }
    }
}
