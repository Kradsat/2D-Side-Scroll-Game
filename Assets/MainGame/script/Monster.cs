using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject player;
    public GameObject prefab;



    public float horizontalSpeed;
    public float angularSpeed;
    public float amplitude;

    private Vector3 startingPosition;
    private bool moving;

    private float angle;

    private bool playerDetected;
    public Transform MonsterPos;
    public float width;
    public float height;
    public LayerMask WhatIsPlayer;

    public Monster[] enemieToBeMoved;
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
        playerDetected = Physics2D.OverlapBox(MonsterPos.position, new Vector2(width, height), 0, WhatIsPlayer);// check if the player is in range

        if (playerDetected == true)
        {
            angle += angularSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x + horizontalSpeed * Time.deltaTime, startingPosition.y + Mathf.Sin(angle) * amplitude, startingPosition.z);
        }
    }
}
