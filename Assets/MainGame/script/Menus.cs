using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject inGameMenu;
    public GameObject inGameMenuPanel;
    public GameObject itemMenu;
    public GameObject systemMenu;
    public bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        inGameMenu.SetActive(false);
        itemMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SetPause();
            inGameMenu.gameObject.SetActive(!inGameMenu.gameObject.activeSelf);
            inGameMenuPanel.gameObject.SetActive(true);
            itemMenu.gameObject.SetActive(false);

        }
    }

    private void SetPause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        isPaused = !isPaused;
        
    }

    public void OpenItemPanel()
    {
        //SetPause();
        inGameMenuPanel.gameObject.SetActive(false );
        itemMenu.gameObject.SetActive(true);
    }

    public void OpenSystemPanel()
    {
        inGameMenuPanel.gameObject.SetActive(false);
        systemMenu.gameObject.SetActive(true);
    }

}
