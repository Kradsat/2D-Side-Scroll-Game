using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    

    public Item item;
    [SerializeField] Dialog dialog;

    public void Interact()
    {
        DialogManager.Instance.ShowDialog(dialog);
    }
}
