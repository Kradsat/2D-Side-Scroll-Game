using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    public void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Z))
    //    {
    //        Pickup();
    //        Debug.Log("is colliding");
    //    }
    //}
    private void OnMouseDown()
    {
        Pickup();
    }
}
