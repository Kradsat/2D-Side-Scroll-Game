using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Count : MonoBehaviour
{

    // count each action of the player => opening a door, take stair, change Frame!!!
    // starting 7 action the ghost may appear
    public int keepCount;
    public bool doAction;



    private void Start()
    {
        keepCount = 0;
    }

}
