using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPickableItem : MonoBehaviour
{
    public Charactercontroller charactercontroller;
    [SerializeField] ItemController itemController;
    [SerializeField]
    DialogManager dialogManager;
    public bool isInteractable = false;
    [SerializeField]
    Direction direction;

    private void Start()
    {
        GetComponentInChildren<BoxCollider2D>();
    }
    private void Update()
    {
        Interraction();
    }

    private void Interraction()
    {
        if(isInteractable==true && Input.GetKeyDown(KeyCode.Z) && charactercontroller.direction == direction && dialogManager.dialogueShow == false )
        {
            dialogManager.thereIsItem = false;
            dialogManager.thereIsNovel = false;
            charactercontroller.stillWalking = false;
            itemController.Interact();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isInteractable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isInteractable = false;
        }
    }
}
