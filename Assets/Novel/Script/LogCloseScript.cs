using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogCloseScript : MonoBehaviour
{
    [SerializeField]
    Button close;
    [SerializeField]
    GameObject log;

    // Start is called before the first frame update
    void Start()
    {
        close.onClick.AddListener(CloseLog);
    }

    void CloseLog()
    {
        log.SetActive(false);
    }
}
