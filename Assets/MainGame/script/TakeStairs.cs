using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeStairs : MonoBehaviour
{
    public  Charactercontroller characterController;
    private bool playerDetected;
    public Transform stairPos;
    public float width;
    public float height;
    public Transform player;
    public float xPos;
    public float yPos;
    public GameObject currentScene;
    public GameObject newScene;
    public Count count;

    [SerializeField]
    GameObject playerGameObject;

    public int floorNum;  

    public LayerMask WhatIsPlayer;

    public AudioSource audioSource;
    public LoadScene loadscene;

    [SerializeField]
    GameObject nextStair;
    Vector2 nextStairPos;

    private void Start() 
    {
        nextStairPos = nextStair.transform.position;
       
    }

    private void Update()
    {
        TakeStair();      
    }

    private void TakeStair()
    {
        playerDetected = Physics2D.OverlapBox(stairPos.position, new Vector2(width, height), 0, WhatIsPlayer);
      


        if (count.audioStop == false)
        {
            audioSource.Stop();
        }

        if (playerDetected == true) // check the player 
        {
            if (Input.GetKeyDown(KeyCode.Z) && characterController.isFront )
            {
                count.audioStop = true;
                player.position = new Vector2(nextStairPos.x, nextStairPos.y);// generate the new position of the player avec key pressed
                currentScene.SetActive(false);// desactivate current scene
                newScene.SetActive(true); // activate new scene
                count.doAction = true; // check the action
                count.keepCount++; // add 1 action to the count
                count.keepCountOnlyMovement++;
                playerGameObject.GetComponent<Charactercontroller>().playerWhichFloor = (WhichFloor)floorNum;
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                loadscene.transitionDoor.SetTrigger("DoorOpen");
            }

        }
       
    }
    
    private void OnDrawGizmosSelected()// draw the collider for the stair
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(stairPos.position, new Vector3(width, height, 1));
    }
}
