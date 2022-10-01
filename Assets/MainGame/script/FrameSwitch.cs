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
       // count = GetComponent<Count>();
    }

    //public bool exit;

    //private void Start()
    //{
    //    exit = true;
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    exit = true;



    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(frame1.activeInHierarchy == true )
        {
            //exit = false;
            frame1.SetActive(false);
            frame2.SetActive(true);
            count.doAction = true;
            count.keepCount++;
            
        }
        else if(frame1.activeInHierarchy == false)
        {
            //exit = false;
            frame1.SetActive(true);
            frame2.SetActive(false);
            count.doAction = true;
            count.keepCount++;
        }
    }

}
