using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoor : MonoBehaviour
{
    private bool playerDetected;
    public float width;
    public float height;
    public Transform doorPos;
    public LayerMask WhatIsPlayer;
    public GameObject currentRoom;
    public GameObject nextRoom;
    public Transform player;
    public float xPos;
    public float yPos;
    public Count count;


 

    // Update is called once per frame
    private void Update()
    {
        OpenTheDooor();


    }

    private void OnDrawGizmosSelected()// draw the box of the door
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(doorPos.position, new Vector3(width, height, 1));
    }

    public void OpenTheDooor() // function for open the door
    {
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0, WhatIsPlayer);// check the player 

        if (playerDetected == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if(currentRoom.activeInHierarchy == true)
                {
                    //exit = false;
                    currentRoom.SetActive(false);
                    nextRoom.SetActive(true);
                    NextRoom();
                    count.doAction = true;
                    count.keepCount++;
                }
                else if (currentRoom.activeInHierarchy == false)
                {
                    //exit = false;
                    currentRoom.SetActive(true);
                    nextRoom.SetActive(false);
                    count.doAction = true;
                    count.keepCount++;
                }
            }
        }
    }

    public void NextRoom()
    {
        player.position = new Vector2(xPos, yPos);
    }
}
