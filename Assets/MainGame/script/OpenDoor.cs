using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool playerDetected;
    public Transform doorPos;
    public float width;
    public float height;

    SceneSwitch sceneSwitch;

    [SerializeField]
    private string sceneName;


    public LayerMask WhatIsPlayer;

    private void Start()
    {
        sceneSwitch = FindObjectOfType<SceneSwitch>();
    }
    private void Update()
        {
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0, WhatIsPlayer);

        if(playerDetected == true)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                sceneSwitch.switchScene(sceneName);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(doorPos.position, new Vector3(width, height, 1));
    }
}
