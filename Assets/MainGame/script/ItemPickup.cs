using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    TextAsset csv;

    [SerializeField]
    Sprite itemSprite;

    public Charactercontroller characterController;
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
    Direction direction;
    bool isInteractable = true;

    [SerializeField]
    GameNovel gameNovel;

    public List<Dialogue> dialogue;

    public GameObject popUpButtonPress;

    int currentLine = 0;
    public void Pickup()
    {
        dialogManager.item = item;
        //Destroy(gameObject);       
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
            popUpButtonPress.SetActive(true);

        }     
        else 
        {
            popUpButtonPress.SetActive(false);
        }
    }

    private void PressedZ()
    {
        if (Input.GetKeyDown(KeyCode.Z) /*&& characterController.direction == direction*/ && isInteractable == true)
        {
            isInteractable = false;
            dialogManager.thereIsItem = true;
            dialogManager.thereIsNovel = true;
            characterController.stillWalking = false;
            gameNovel.csv = csv;
            dialogManager.itemImage.sprite = itemSprite;
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
