using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactercontroller : MonoBehaviour
{

    [SerializeField]
    Sprite[] characterSprite;
    SpriteRenderer _spriteRenderer;

    bool isWalking;
    bool stillWalking;
   
    [SerializeField]
    Sprite faceCamera;
    [SerializeField]
    Sprite faceOtherSide;

    float moveSpeed = 20f;

    int animationCount = 0;
    int animationSpeed = 9;

    int frame = 0;
    private void Awake()
    {
        transform.eulerAngles = new Vector2(0, 180);
        isWalking = false;
        stillWalking = false;
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = characterSprite[1];

    }

    private void FixedUpdate()
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
        //move right
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector2(0, 180);//rotate to the right
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * -moveSpeed * Time.deltaTime, 0f));

            //animation
            isWalking = true;
            //StopCoroutine(Animate());
            //StartCoroutine(Animate());
        }

        //move left
        else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector2(0, 0);//rotate to the left
            
            {
                transform.Translate(new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0f));

                //animation
                isWalking = true;
                //StopCoroutine(Animate());
                //StartCoroutine(Animate());
            }
        }
      
        //stop animation
        else
        {
            isWalking = false;
            //StopCoroutine(Animate());
            _spriteRenderer.sprite = characterSprite[1];

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _spriteRenderer.sprite = faceOtherSide;

        }
    }

    //Coroutine for animation
    //IEnumerator Animate()
    //{
    //    while(isWalking == true && stillWalking == false)
    //    {
    //        stillWalking = true;
    //        for( int i = 0; i < 4; i++)
    //        {
    //            this.GetComponent<SpriteRenderer>().sprite = characterSprite[i];
    //            yield return new WaitForSeconds(0.3f); 
    //        }
    //        stillWalking = false;
    //    }
    //}
}
