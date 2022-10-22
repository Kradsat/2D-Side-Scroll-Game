using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SceneChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public void Title( ) {
        SceneManager.LoadScene( "Title" );
    }    

    public TextMeshProUGUI theText;

    public void OnPointerEnter( PointerEventData eventData ) {
        theText.color = Color.red; //Or however you do your color
    }

    public void OnPointerExit( PointerEventData eventData ) {
        theText.color = Color.white; //Or however you do your color
    }
}
