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

    [SerializeField]
    public WhichFloor playerWhichFloor;
    [SerializeField]
    public Direction direction;

    bool isWalking;
    bool stillWalking;
    public bool isFront;
    public bool isBack;
    private bool playerDetected;

    public Sprite faceCamera;
    public Sprite faceOtherSide;

    public Transform EdgePosLeftFirstfloor;
    
    public Transform EdgePosLeftSecondfloor;

    public Transform EdgePosRight;
    public float width;
    public float height;
    public float xPosLeft;
    public float xposRight;
    public float widthSecondFloor;
    public float heightSecondFloor;
    public float xPosLeftSecondFloor;

    public LayerMask WhatIsPlayer;
    public Transform player;

    public float moveSpeed = 20f;

    int animationCount = 0;
    int animationSpeed = 9;

    [SerializeField]
    GameObject[] corridorUI;   

    int frame = 0;

    AudioSource audioSource;
    
    [SerializeField]
    Count count;

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
        _spriteRenderer.sprite = characterSprite[0];
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate() // animation fixed Update
    {
        animationCount += 1;

        if (animationCount % animationSpeed == 0)
        { frame += 1; }

        if (isWalking)
        {
            _spriteRenderer.sprite = characterSprite[frame % 8];
        }

      
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        StopMovementOnEdgeLeft();
        StopMovementOnEdgeRight();
        // DebugMovementRight();
        // DebugMovementLeft();
        CorridorTextShow();
        WalkingBGM();
    }

    public void StopMovementOnEdgeLeft()// block the character by reseting is transform position
    {
        playerDetected = Physics2D.OverlapBox(EdgePosLeftFirstfloor.position, new Vector2(width, height), 0, WhatIsPlayer);
        if (playerDetected == true)
        {
            player.position = new Vector2(xPosLeft, transform.position.y);

        }
        playerDetected = Physics2D.OverlapBox(EdgePosLeftSecondfloor.position, new Vector2(widthSecondFloor, heightSecondFloor), 0, WhatIsPlayer);
        if (playerDetected == true)
        {
            player.position = new Vector2(xPosLeftSecondFloor, transform.position.y);

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

    // public void DebugMovementRight()
    // {
    //     if(Input.GetKey(KeyCode.A))
    //     {
    //         player.position = new Vector3(player.position.x - 2, player.position.y,0);
    //     }
    // }
    // public void DebugMovementLeft()
    // {
    //     if (Input.GetKey(KeyCode.S))
    //     {
    //         player.position = new Vector3(player.position.x + 2, player.position.y, 0);
    //     }
    // }
    public void Movement()
    {
        //move right
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Direction.Right;
            transform.eulerAngles = new Vector2(0, 180);//rotate to the right
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * - moveSpeed * Time.deltaTime, 0f));

            //animation
            isWalking = true;
            isFront = false;
            isBack = false;
        }

        //move left
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector2(0, 0);//rotate to the left

            {
                direction = Direction.Left;
                transform.Translate(new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0f));

                //animation
                isWalking = true;
                isFront = false;
                isBack = false;

                //BGM
            }
        }

        //stop animation
        else
        {
            if( Input.GetKey( KeyCode.UpArrow ) ) {
                direction = Direction.Back;
                _spriteRenderer.sprite = faceOtherSide;
                isFront = true;
                isBack = false;
                isWalking = false;

            } else if( Input.GetKey( KeyCode.DownArrow ) ) {
                direction = Direction.Front;
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
                _spriteRenderer.sprite = characterSprite[ 0];
            }
        }
    }

    private void OnDrawGizmosSelected() // draw the edge of the map
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(EdgePosLeftFirstfloor.position, new Vector3(width, height, 1));
        Gizmos.DrawCube(EdgePosLeftSecondfloor.position, new Vector3(widthSecondFloor, heightSecondFloor, 1));
        Gizmos.DrawCube(EdgePosRight.position, new Vector3(width, height, 1));
    }

   void CorridorTextShow()
   {
        for(int i = 0; i < corridorUI.Length; i++)
        {
            if(count.canSpawnhere == true && (int)playerWhichFloor == i)
            {
                corridorUI[i].SetActive(true);
            }
            else
            {
                corridorUI[i].SetActive(false);
            }
        }
   }

   void WalkingBGM()
   {
        if (isWalking)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }
        else
        {
            audioSource.Stop();
        }   
    }
}
