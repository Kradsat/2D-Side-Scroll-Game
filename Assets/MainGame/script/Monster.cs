using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
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
            float dis1 = Vector3.Distance(doors[0].position, transform.position);
            float dis2 = Vector3.Distance(doors[1].position, transform.position);

            if(dis1 > dis2)
            {
                transform.position = Vector3.MoveTowards(transform.position, doors[1].transform.position, speed);// moving toward player
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, doors[0].transform.position, speed);// moving toward player
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
}
