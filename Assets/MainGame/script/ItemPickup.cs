using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    TextAsset csv;

    public Item item;
    public float width;
    public float height;
    public LayerMask WhatIsPlayer;
    public Transform itemPos;

    public bool playerDetectedItemRange;
   
    public GameObject player;
   
    [SerializeField] ItemController itemController;
    [SerializeField]
    DialogManager dialogManager;

    [SerializeField]
    GameNovel gameNovel;

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
       

        Debug.Log(playerDetectedItemRange);

        if (playerDetectedItemRange == true)
        {
            PressedZ();
        }        
    }

    private void PressedZ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            dialogManager.thereIsItem = true;
            gameNovel.csv = csv;
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
