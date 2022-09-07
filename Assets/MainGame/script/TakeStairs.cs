using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeStairs : MonoBehaviour
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

    public LayerMask WhatIsPlayer;

    private void Update()
    {
        playerDetected = Physics2D.OverlapBox(stairPos.position, new Vector2(width, height), 0, WhatIsPlayer);

        if (playerDetected == true)
        {
           
            
             if (Input.GetKeyDown(KeyCode.Z))
                {
                    player.position = new Vector2(xPos, yPos);
                currentScene.SetActive(false);
                newScene.SetActive(true);
                }

            
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(stairPos.position, new Vector3(width, height, 1));
    }
}
