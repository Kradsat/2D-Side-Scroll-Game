using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteDialogue : MonoBehaviour
{
    [SerializeField]
    ReadText readText;

    int dialogueSpeed;

    // Start is called before the first frame update
    void Start()
    {
        dialogueSpeed = 50;
    }

    // Update is called once per frame
    public IEnumerator WriteText(string sentence)
    {
        float t = 0;
        int charIndex = 0;

        while (charIndex < sentence.Length)
        {
			t += Time.deltaTime * dialogueSpeed;
			charIndex = Mathf.FloorToInt(t);
			charIndex = Mathf.Clamp(charIndex, 0, sentence.Length);
            readText.dialogueText.text = sentence.Substring(0, charIndex);

			yield return null;
        }

    }
}
