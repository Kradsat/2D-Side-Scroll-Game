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

    int count;
    
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

    public void AddLog(string sentence, int lineCount, string character)
    {
        GameObject box;

        var rectTransform = parentObject.GetComponent<RectTransform>();
        var width = rectTransform.sizeDelta.x;
        var height = rectTransform.sizeDelta.y;

        if(lineCount >= 3)
        {
            height += 200;
            parentObject.GetComponent<VerticalLayoutGroup>().enabled = true;
            parentObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,height);
        }

        if(lineCount % 2 == 0)
        {
            box = Instantiate(RedDialogue, new Vector3(960, 500 - (lineCount * 200), 0), Quaternion.identity);
        }
        else
        {
            box = Instantiate(BlackDialogue, new Vector3(960, 500 - (lineCount * 200), 0), Quaternion.identity);
        }
        box.transform.SetParent(parentObject.transform, true);
        textBoxComponent = box.GetComponentInChildren<TextBoxComponent>();
        textBoxComponent.SetText(sentence);

        //character UI
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
        else
        {
            count = 4;
        }
        textBoxComponent.SetImage(count);
    }
}
