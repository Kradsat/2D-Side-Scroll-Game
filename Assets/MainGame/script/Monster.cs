using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WhichFloor
{
    First,
    Second,
    Third
}

public class Monster : MonoBehaviour
{
    [SerializeField]
    WhichFloor whichFloor;

    private Collider2D playerCollider2D = null;
    public Transform player;
    public GameObject prefab;

    public GameObject[] doorObject;
    public Transform[] doors;

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

        player = playerCollider2D.transform;
        var speed = horizontalSpeed * Time.deltaTime; // monster speed
        var targetPos = new Vector3(player.position.x, player.position.y, transform.position.z);// player transform target
    
       
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
            float dis1FirstFloor = Vector3.Distance(doors[0].position, transform.position);
            float dis2FirstFloor = Vector3.Distance(doors[1].position, transform.position);
            float dis1SecondFloorUp = Vector3.Distance(doors[2].position, transform.position);
            float dis2SecondFloorUp = Vector3.Distance(doors[3].position, transform.position);
            float dis1SecondFloorDown = Vector3.Distance(doors[4].position, transform.position);
            float dis2SecondFloorDown = Vector3.Distance(doors[5].position, transform.position);
            float dis1ThirdFloor = Vector3.Distance(doors[6].position, transform.position);
            float dis2ThirdFloor = Vector3.Distance(doors[7].position, transform.position);

            // if(whichFloor.First)
            // {

            // }
            if (dis1FirstFloor > dis2FirstFloor)
            {
                transform.position = Vector3.MoveTowards(transform.position, doors[1].transform.position, speed);// moving toward player
                Debug.Log(doorObject);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, doors[0].transform.position, speed);// moving toward player
            }

            //if(dis1ThirdFloor > dis2ThirdFloor)
            //{
            //    transform.position = Vector3.MoveTowards(transform.position, doors[7].transform.position, speed);// moving toward player

            //}
            //else
            //{
            //    transform.position = Vector3.MoveTowards(transform.position, doors[6].transform.position, speed);// moving toward player

            //}
            //if(targetPos.y > transform.position.y)
            //{
            //    if(dis1SecondFloorUp > dis2SecondFloorUp)
            //    {
            //        transform.position = Vector3.MoveTowards(transform.position, doors[3].transform.position, speed);// moving toward player
            //    }
            //    else
            //    {
            //        transform.position = Vector3.MoveTowards(transform.position, doors[2].transform.position, speed);// moving toward player
            //    }
            //}

            //else if(targetPos.y < transform.position.y)
            //{
            //    if(dis1SecondFloorDown > dis2SecondFloorDown)
            //    {
            //        transform.position = Vector3.MoveTowards(transform.position, doors[5].transform.position, speed);// moving toward player
            //    }
            //    else
            //    {
            //        transform.position = Vector3.MoveTowards(transform.position, doors[4].transform.position, speed);// moving toward player
            //    }
            //}
        }
    }

    public void GetDoorPosition(int num)
    {
        for(int i = 0; i < num; i++)
        {
            doors[i] = doorObject[i].transform;
        }
    }
}
