using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitch : MonoBehaviour
{
    public GameObject frame1;
    public GameObject frame2;
    public MonsterManager monsterManager;
    public float distance;
    public GameObject player;

    [SerializeField]protected Count count;


    private void Update()
    {
        DesactiveBackground();
    }
    private void DesactiveBackground()
    {
        distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        Debug.Log(distance);

        if (distance > 100)
        {
            frame1.SetActive(false);
            frame2.SetActive(false);
        }
        else
        {
            frame1.SetActive(true);
            frame2.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)// function to change beetween frame/map
    {
        if(other.tag == "Player")
        {
            count.doAction = true;
            count.keepCount++;
            count.audioStop = false;
            if (monsterManager.canDisepear == true)
            {
                count.keepCountOnlyMovement++;
            }
        }
    }
}
