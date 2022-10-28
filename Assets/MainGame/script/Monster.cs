using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    public WhichFloor monsterWhichFloor;

    private Collider2D playerCollider2D = null;
    public Transform playerPosition;

    public GameObject[] doorObject;
    public Transform[] doors;

    public GameObject player;

    public float horizontalSpeed;
    

    private Vector3 startingPosition;
    private bool moving;


    public bool takeStair = false;
    public bool takeStairD = false;

    private bool playerDetected;
    public Transform MonsterPos;
    public float width;
    public float height;
    public LayerMask WhatIsPlayer;
    public SpriteRenderer sprite;

    float shortestDistance = Mathf.Infinity;

    void Start()
    { 
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovementEnemy();
    }


    private void OnDrawGizmosSelected() // draw the distance beetween the monster and player 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(MonsterPos.position, new Vector3(width, height, 1));
    }


    public void MovementEnemy()// function to move the monster
    {
        playerCollider2D = Physics2D.OverlapBox(MonsterPos.position, new Vector2(width, height), 0, WhatIsPlayer);// check if the player is in range
        if (playerCollider2D == null)
        {
            return;
        }

        playerPosition = playerCollider2D.transform;
        var speed = horizontalSpeed * Time.deltaTime; // monster speed
        var targetPos = new Vector3(playerPosition.position.x, playerPosition.position.y, transform.position.z);// player transform target
    
       
        if(targetPos.x < transform.position.x) // flip the monster sprite
        {
            sprite.flipX = true;
        }

        if(targetPos.y == transform.position.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);// moving toward player
        }
        else if(targetPos.y != transform.position.y)
        {
            float[] disFloor = new float[7];
            for(int i = 0; i < 7; i++)
            {
                disFloor[i] = Vector3.Distance(doors[i].position, transform.position); 
            }

            //going up
            if(targetPos.y > transform.position.y)
            {
                if(monsterWhichFloor == WhichFloor.First)
                {
                    if (disFloor[0] > disFloor[1])
                    {
                        transform.position = Vector3.MoveTowards(transform.position, doors[1].transform.position, speed);// moving toward player
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, doors[0].transform.position, speed);// moving toward player
                    }                
                }      
                else if(monsterWhichFloor == WhichFloor.Second)
                {
                    if (disFloor[0] > disFloor[1])
                    {
                        transform.position = Vector3.MoveTowards(transform.position, doors[3].transform.position, speed);// moving toward player
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, doors[2].transform.position, speed);// moving toward player
                    }                
                }                
            }
            else if(targetPos.y < transform.position.y)
            {
                if(monsterWhichFloor == WhichFloor.Second)
                {
                    if (disFloor[0] > disFloor[1])
                    {
                        transform.position = Vector3.MoveTowards(transform.position, doors[5].transform.position, speed);// moving toward player
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, doors[4].transform.position, speed);// moving toward player
                    }                
                }      
                else if(monsterWhichFloor == WhichFloor.Third)
                {
                    if (disFloor[0] > disFloor[1])
                    {
                        transform.position = Vector3.MoveTowards(transform.position, doors[7].transform.position, speed);// moving toward player
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, doors[6].transform.position, speed);// moving toward player
                    }                
                }                
            }
        }
    }

    public void GetDoorPosition(int num)
    {
        for(int i = 0; i < num; i++)
        {
            doors[i] = doorObject[i].transform;
        }
    }

    public void GetMonsterFloorData(int num)
    {
        monsterWhichFloor = (WhichFloor)num;
    }
}
