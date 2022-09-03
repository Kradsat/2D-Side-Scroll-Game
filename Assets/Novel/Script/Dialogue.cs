using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    [TextArea (3,10)]
    public string[] sentences;
    string ui;
    string se;
    string bgm;
    string item;
    string animation;
    string effect;
    string background;
}
