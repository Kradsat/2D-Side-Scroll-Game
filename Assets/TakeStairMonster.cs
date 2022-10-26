using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeStairMonster : MonoBehaviour
{
    private bool monsterDetected;
    public Transform stairPos;
    public float width;
    public float height;
    public Transform monster;
    public float xPos;
    public float yPos;    

    public LayerMask WhatIsMonster;
    public MonsterManager manager;

    [SerializeField]
    GameObject nextStair;
    Vector3 NextStairPos;

    [SerializeField]
    GameObject playerGameObject;
    public Vector2 playerPos;

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
            monster = manager.newInstance.transform;
        
            if (monsterDetected == true) // check the player 
            {
                if(this.tag == "StairUp" && playerPos.y > monster.position.y)
                {
                    monster.position = new Vector2(NextStairPos.x, NextStairPos.y);// generate the new position of the player avec key pressed
                }
                else if(this.tag == "StairDown" && playerPos.y < monster.position.y)
                {
                    monster.position = new Vector2(NextStairPos.x, NextStairPos.y);// generate the new position of the player avec key pressed
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
