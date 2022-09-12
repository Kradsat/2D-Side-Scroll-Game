using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogButton : MonoBehaviour
{
    [SerializeField]
    GameObject RedDialogue;
    [SerializeField]
    GameObject BlackDialogue;

    [SerializeField]
    Button button;
    [SerializeField]
    GameObject log;

    [SerializeField]
    GameObject parentObject;

    TextBoxComponent textBoxComponent;
    
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OpenLog);
    }

    // Update is called once per frame
    void OpenLog()
    {
        log.SetActive(true);
    }

    public void AddLog(string sentence)
    {
        //textBoxComponent = new TextBoxComponent();
        GameObject box = Instantiate(RedDialogue, new Vector3(960, 0, 0), Quaternion.identity);
        box.transform.parent = parentObject.transform;
        textBoxComponent = box.GetComponentInChildren<TextBoxComponent>();
        //textBoxComponent = box.GetComponent<TextBoxComponent>();
        Debug.Log(sentence);
        textBoxComponent.GetText(sentence);
    }
}
