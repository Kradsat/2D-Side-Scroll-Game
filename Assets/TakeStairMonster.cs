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


 





    private void Update()
    {
        TakeStair();

    }

    private void TakeStair()
    {
        monsterDetected = Physics2D.OverlapBox(stairPos.position, new Vector2(width, height), 0, WhatIsMonster);


        monster = manager.newInstance.transform;
      

        if (monsterDetected == true) // check the player 
        { 

         monster.position = new Vector2(xPos, yPos);// generate the new position of the player avec key pressed
              

            

        }

    }

    private void OnDrawGizmosSelected()// draw the collider for the stair
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(stairPos.position, new Vector3(width, height, 1));
    }


}
