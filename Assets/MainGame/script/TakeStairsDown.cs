using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeStairsDown : MonoBehaviour
{
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

    public LayerMask WhatIsPlayer;

    public AudioSource audioSource;
    



    private void Update()
    {
        TakeStairD();
    }

    private void TakeStairD()
    {
        playerDetected = Physics2D.OverlapBox(stairPos.position, new Vector2(width, height), 0, WhatIsPlayer);

        Debug.Log(audioSource);


        if (count.audioStop == false)
        {
            audioSource.Stop();
        }

        if (playerDetected == true) // check the player 
        {
            



            if (Input.GetKeyDown(KeyCode.Z))
            {
                count.audioStop = true;
                player.position = new Vector2(xPos, yPos);// generate the new position of the player avec key pressed
                currentScene.SetActive(false);// desactivate current scene
                newScene.SetActive(true); // activate new scene
                count.doAction = true; // check the action
                count.keepCount++; // add 1 action to the count
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }

            }

        }
    }
    private void OnDrawGizmosSelected()// draw the collider for the stair
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(stairPos.position, new Vector3(width, height, 1));
    }
}
