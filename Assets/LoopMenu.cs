using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopMenu : MonoBehaviour
{
    void Start()
    {
        
        var selects = GetComponentsInChildren<Selectable>();
        for (var i = 0; i < selects.Length; i++)
        {
            var nav = selects[i].navigation;
            nav.mode = Navigation.Mode.Explicit;
            nav.selectOnUp = selects[i == 0 ? selects.Length - 1 : i - 1];
            nav.selectOnDown = selects[(i + 1) % selects.Length];
            selects[i].navigation = nav;
        }
    }
}