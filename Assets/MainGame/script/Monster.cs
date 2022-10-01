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
      //  moving = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        MovementEnemy();


        //    if (moving) // moving in x 
        //    {
        //    }
        //    else
        //    {
        //        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.z, transform.position.x), 25); // check range of player and move if in range
        //        foreach (Collider2D collider in colliders)
        //        {
        //            if(collider.gameObject.tag =="Player")
        //            {
        //                moving = true;
        //            }
        //        }

        //    }
        //}

        //public void Move()
        //{
        //    moving = true;

        //    foreach (Monster monster in enemieToBeMoved)
        //    {
        //        monster.Move();
        //    }
    }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(MonsterPos.position, new Vector3(width, height, 1));
        }

    public void MovementEnemy()
    {
        playerDetected = Physics2D.OverlapBox(MonsterPos.position, new Vector2(width, height), 0, WhatIsPlayer);

        if (playerDetected == true)
        {
            angle += angularSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x + horizontalSpeed * Time.deltaTime, startingPosition.y + Mathf.Sin(angle) * amplitude, startingPosition.z);
        }
    }
}
