using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog 
{
    [SerializeField] public List<string> lines;

    public List<string> Lines
    {
        get { return lines;  }
    }
}
