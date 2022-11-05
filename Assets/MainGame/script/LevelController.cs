using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    [SerializeField] private int itemCount;

    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (InventoryManager.Instance.itemCount == itemCount)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
