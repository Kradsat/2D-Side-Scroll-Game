using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Transform EdgePosLeft;
    public Transform EdgePosRight;
    public float width;
    public float height;
    public float xPosLeft;
    public float xposRight;
    
    private bool playerDetected;

    public LayerMask WhatIsPlayer;
    public Transform player;

    [SerializeField]
    Charactercontroller characterController;   

   
    private void Update()
    {
        RoomEdgeRight();
        RoomEdgeLeft();
    }

    private void RoomEdgeRight()
    {
        playerDetected = Physics2D.OverlapBox(EdgePosRight.position, new Vector2(width, height), 0, WhatIsPlayer);
        if (playerDetected == true)
        {
            player.position = new Vector2(player.position.x + characterController.moveSpeed * Time.deltaTime, player.transform.position.y);
        }
    }

    private void RoomEdgeLeft()
    {
        playerDetected = Physics2D.OverlapBox(EdgePosLeft.position, new Vector2(width, height), 0, WhatIsPlayer);
        if (playerDetected == true)
        {
            player.position = new Vector2(player.position.x - characterController.moveSpeed * Time.deltaTime, player.transform.position.y);
        }
    }
    private void OnDrawGizmosSelected() // draw the edge of the map
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(EdgePosLeft.position, new Vector3(width, height, 1));
        Gizmos.DrawCube(EdgePosRight.position, new Vector3(width, height, 1));
    }

  
}
