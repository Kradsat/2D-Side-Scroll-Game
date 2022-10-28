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

    public bool playerDetectedItemRange;
    public bool playerDetectedCheckRange;
    public GameObject player;
    public GameObject UI;
    [SerializeField] ItemController itemController;

    int currentLine = 0;
    public void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    private void Update()
    {
        DetectCollider();
    }
    
    private void DetectCollider()
    {
        playerDetectedItemRange = Physics2D.OverlapBox(itemPos.position, new Vector2(width, height), 0, WhatIsPlayer);
        playerDetectedCheckRange = Physics2D.OverlapBox(itemPos.position, new Vector2(width, height), 0, WhatIsPlayer);

        Debug.Log(playerDetectedItemRange);

        if (playerDetectedItemRange == true || playerDetectedCheckRange == true)
        {
            PressedZ();
        }        
    }

    private void PressedZ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            itemController.Interact();            
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
