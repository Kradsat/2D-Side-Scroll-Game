using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuExitScript : MonoBehaviour
{
    public Button MenuButton;

    public GameObject MenuUI;
    public GameObject MenuScreen;

    // Start is called before the first frame update
    void Start()
    {
        MenuButton.onClick.AddListener(ExitClick);
    }

    void ExitClick()
    {
        MenuUI.SetActive(false);
        MenuScreen.SetActive(false);
    }
}
