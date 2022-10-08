using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonScript : MonoBehaviour
{
    public Button ExitButton;

    public GameObject MenuUI;
    public GameObject MenuScreen;
    // Start is called before the first frame update
    void Start()
    {
        ExitButton.onClick.AddListener(MenuClick);
    }

    void MenuClick()
    {
        MenuUI.SetActive(true);
        MenuScreen.SetActive(true);
    }
}
