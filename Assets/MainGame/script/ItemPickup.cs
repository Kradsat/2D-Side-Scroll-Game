using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public float width;
    public float height;
    public LayerMask WhatIsPlayer;
    public Transform itemPos;

    public bool playerDetected;
    public GameObject player;

    public void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerDetected = Physics2D.OverlapBox(itemPos.position, new Vector2(width, height), 0, WhatIsPlayer);
        

        Debug.Log(playerDetected);

    
        

        if (playerDetected == true && Input.GetKeyDown(KeyCode.Z))
        {
            Pickup();
            Debug.Log("is colliding");
        }
    }

    private void OnDrawGizmosSelected()// draw the collider for the item
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(itemPos.position, new Vector3(width, height, 1));
    }
}
