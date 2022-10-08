using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitch : MonoBehaviour
{
    public GameObject frame1;
    public GameObject frame2;
    

    [SerializeField]protected Count count;

    private void Start()
    {
       
    }


    private void OnTriggerEnter2D(Collider2D collision)// function to change beetween frame/map
    {
        if(frame1.activeInHierarchy == true )
        {
            //exit = false;
            frame1.SetActive(false);
            frame2.SetActive(true);
            count.doAction = true;
            count.keepCount++;
            count.audioStop = false;
            
        }
        else if(frame1.activeInHierarchy == false)
        {
            //exit = false;
            frame1.SetActive(true);
            frame2.SetActive(false);
            count.doAction = true;
            count.keepCount++; // add one action
            count.audioStop = false;
        }
    }

}
