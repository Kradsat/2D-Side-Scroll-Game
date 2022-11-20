using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoor : MonoBehaviour
{
    public Charactercontroller characterController;
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
   AudioSource audioSource;
   [SerializeField]
   Direction direction;


    public LoadScene loadscene;
    public GameObject popUpButtonPress;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
       

    }
    // Update is called once per frame
    private void Update()
    {
        
        OpenTheDooor();

        PopUp();

    }

    private void OnDrawGizmosSelected()// draw the box of the door
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(doorPos.position, new Vector3(width, height, 1));
    }

    public void OpenTheDooor() // function for open the door
    {
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0, WhatIsPlayer);// check the player 
        Debug.Log(audioSource);
        

        if (count.audioStop == false)
        {
            audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Z) && characterController.direction == direction )
        {
                    

            if (playerDetected == true && Input.GetKeyDown(KeyCode.Z) )
            {
               
                count.audioStop = true;
                if(currentRoom.activeInHierarchy == true)
                {
                    //exit = false;
                    currentRoom.SetActive(false);
                    nextRoom.SetActive(true);
                    NextRoom();
                    count.doAction = true;
                    count.keepCount++;
                    if (!audioSource.isPlaying)
                    {
                        audioSource.Play();
                        
                    }
                    loadscene.transitionDoor.SetTrigger("DoorOpen");
                    
                    
                }
                else if (currentRoom.activeInHierarchy == false)
                {
                    //exit = false;
                    currentRoom.SetActive(true);
                    nextRoom.SetActive(false);
                    count.doAction = true;
                    count.keepCount++;
                    count.canSpawnhere = true;
                    if (!audioSource.isPlaying)
                    {
                        audioSource.Play();
                    }
                    loadscene.transitionDoor.SetTrigger("DoorClose");
                }
                

                if (currentRoom.tag == "Loft") // check tag
                {
                    count.canSpawnhere = false;
                    

                }
                else
                {
                    count.canSpawnhere = true;
                   
                
                }
            }

        }
            
        
       
    }

    public void PopUp()
    {
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0, WhatIsPlayer);// check the player 

        if(playerDetected == true)
        {
            popUpButtonPress.SetActive(true);
        }
        else
        {
            popUpButtonPress.SetActive(false);
        }
    }

    public void NextRoom() // move to next room 
    {
        player.position = new Vector2(xPos, yPos);
    }
  
}
