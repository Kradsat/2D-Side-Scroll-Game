using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterNotes : MonoBehaviour
{
    [SerializeField]
    GameObject notes;
    [SerializeField]
    Button button;
    [SerializeField]
    Charactercontroller characterController;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(ButtonPress);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.LeftArrow))
        {
            ButtonPress();
        }
    }

    // Update is called once per frame
    void ButtonPress()
    {
        notes.SetActive(false);
        characterController.stillWalking = true;
    }
}
