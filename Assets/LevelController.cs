using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    [SerializeField] private int itemCount;
    public DialogManager dialogManager;

    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (InventoryManager.Instance.itemCount == itemCount && dialogManager.isTyping !=true)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
