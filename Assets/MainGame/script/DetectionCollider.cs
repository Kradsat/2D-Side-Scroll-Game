using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCollider : MonoBehaviour
{
    public float width;
    public float height;
    public LayerMask WhatIsPlayer;
    public bool playerDetected;
    public GameObject player;
    public Transform itemPos;

    private void Update()
    {
        DetectCollider();
    }
    private void DetectCollider()
    {
        playerDetected = Physics2D.OverlapBox(itemPos.position, new Vector2(width, height), 0, WhatIsPlayer);
        Debug.Log(playerDetected);

        if (playerDetected == true)
        {
            
        }
    }
    private void OnDrawGizmosSelected()// draw the collider for the item
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(itemPos.position, new Vector3(width, height, 1));
    }

}
