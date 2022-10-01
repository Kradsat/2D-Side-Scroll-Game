using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : SceneSwitch
{
    public Transform player;
    public float xPos;
    public float yPos;
    public FrameSwitch frameSwitch;

    public string previous;
    public override void Start()// get to the positin after entering a room
    {
        base.Start();

        if(prevScene == previous)
        {
            player.position = new Vector2(xPos, yPos);
            frameSwitch.frame1.SetActive(false);
            frameSwitch.frame2.SetActive(true);
        }
    }

}
