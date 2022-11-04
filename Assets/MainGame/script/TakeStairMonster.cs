using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeStairMonster : MonoBehaviour
{
    private bool monsterDetected;
    public Transform stairPos;
    public float width;
    public float height;
    public Transform monsterTransform;
    public float xPos;
    public float yPos;  

    public int floorNum;  

    public LayerMask WhatIsMonster;
    public MonsterManager manager;

    [SerializeField]
    GameObject nextStair;
    Vector3 NextStairPos;

    [SerializeField]
    GameObject playerGameObject;
    public Vector2 playerPos;

    [SerializeField]
    Charactercontroller playerController;
    [SerializeField]
    Monster monsterController;

    private void Start() 
    {
        NextStairPos = nextStair.transform.position; 
    }

    private void Update()
    {
        TakeStair();
    }

    private void TakeStair()
    {
        monsterDetected = Physics2D.OverlapBox(stairPos.position, new Vector2(width, height), 0, WhatIsMonster);
        playerPos = playerGameObject.transform.position;

        if(manager.canDisepear == true)
        {
            monsterTransform = manager.newInstance.transform;
            GameObject monster = manager.newInstance;
            monsterController = monster.GetComponent<Monster>();
        
            if (monsterDetected == true) // check the player 
            {
                if(this.tag == "StairUp" && (int)playerController.playerWhichFloor > (int)monsterController.monsterWhichFloor)
                {
                    monsterTransform.position = new Vector2(NextStairPos.x, NextStairPos.y - 10);// generate the new position of the player avec key pressed
                    monster.GetComponent<Monster>().monsterWhichFloor = (WhichFloor)floorNum;                
                }
                else if(this.tag == "StairDown" && (int)playerController.playerWhichFloor < (int)monsterController.monsterWhichFloor)
                {
                    monsterTransform.position = new Vector2(NextStairPos.x, NextStairPos.y - 10);// generate the new position of the player avec key pressed
                    monster.GetComponent<Monster>().monsterWhichFloor = (WhichFloor)floorNum;                
                }
            }
        }
    }

    private void OnDrawGizmosSelected()// draw the collider for the stair
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(stairPos.position, new Vector3(width, height, 1));
    }
}
