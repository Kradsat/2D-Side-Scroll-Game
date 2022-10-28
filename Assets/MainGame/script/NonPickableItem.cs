using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPickableItem : MonoBehaviour
{
    [SerializeField] ItemController itemController;
    public bool isInteractable = false;


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
        if(isInteractable==true && Input.GetKeyDown(KeyCode.Z))
        {
            itemController.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
