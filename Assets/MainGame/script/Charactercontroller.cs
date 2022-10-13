using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Charactercontroller : MonoBehaviour
{

   // public Vector3 startingPosition;
    [SerializeField]
    Sprite[] characterSprite;
    SpriteRenderer _spriteRenderer;

    bool isWalking;
    bool stillWalking;
    bool isFront;
    bool isBack;
    private bool playerDetected;

    [SerializeField]
    Sprite faceCamera;
    [SerializeField]
    Sprite faceOtherSide;

    public Transform EdgePosLeft;
    public Transform EdgePosRight;
    public float width;
    public float height;
    public float xPosLeft;
    public float xposRight;


    public LayerMask WhatIsPlayer;
    public Transform player;

    float moveSpeed = 20f;

    int animationCount = 0;
    int animationSpeed = 9;

   

    int frame = 0;

    AudioSource audioSource;
    
 

    private void Awake()
    {
        transform.eulerAngles = new Vector2(0, 180);
        isWalking = false;
        stillWalking = false;
        isFront = false;
        isBack = false;
    }

    private void Start()
    {
       // startingPosition = transform.position;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = characterSprite[1];
        audioSource = GetComponent<AudioSource>();
       
      
        
    }

    private void FixedUpdate() // animation fixed Update
    {
        animationCount += 1;

        if (animationCount % animationSpeed == 0)
        { frame += 1; }

        if (isWalking)
        {
            _spriteRenderer.sprite = characterSprite[frame % 4];
        }

      
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        StopMovementOnEdgeLeft();
        StopMovementOnEdgeRight();
       
    }

    public void StopMovementOnEdgeLeft()// block the character by reseting is transform position
    {
        playerDetected = Physics2D.OverlapBox(EdgePosLeft.position, new Vector2(width, height), 0, WhatIsPlayer);
        if (playerDetected == true)
        {
            player.position = new Vector2(xPosLeft,transform.position.y);

        }
        
       
    }
    public void StopMovementOnEdgeRight() // block the character by reseting is transform position
    {
        playerDetected = Physics2D.OverlapBox(EdgePosRight.position, new Vector2(width, height), 0, WhatIsPlayer);
        if (playerDetected == true)
        {
            player.position = new Vector2(xposRight,transform.position.y );
        }
        
    }


    public void Movement()
    {

        //move right
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector2(0, 180);//rotate to the right
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * -moveSpeed * Time.deltaTime, 0f));

            //animation
            isWalking = true;
            isFront = false;
            isBack = false;


            //BGM

            if(isWalking)
            {
                if(!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
               
            }
          
               
               
            
            
        }

        //move left
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector2(0, 0);//rotate to the left

            {
                transform.Translate(new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0f));

                //animation
                isWalking = true;
                isFront = false;
                isBack = false;

                //BGM

                if (isWalking)
                {
                    if (!audioSource.isPlaying)
                    {
                        audioSource.Play();
                    }
                   
                }


            }
        }

        //stop animation
        else
        {
            if( Input.GetKey( KeyCode.UpArrow ) ) {
                _spriteRenderer.sprite = faceOtherSide;
                isFront = true;
                isBack = false;
                isWalking = false;

            } else if( Input.GetKey( KeyCode.DownArrow ) ) {
                _spriteRenderer.sprite = faceCamera;
                isBack = true;
                isFront = false;
                isWalking = false;

            }
            if ( !isFront && !isBack ) {
                isWalking = false;
                isFront = false;
                isBack = false;
                //StopCoroutine(Animate());
                _spriteRenderer.sprite = characterSprite[ 1 ];

                if(isWalking == false)
                {
                    audioSource.Stop();
                }
            }

        }
    }

    private void OnDrawGizmosSelected() // draw the edge of the map
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(EdgePosLeft.position, new Vector3(width, height, 1));
        Gizmos.DrawCube(EdgePosRight.position, new Vector3(width, height, 1));
    }

   

}
