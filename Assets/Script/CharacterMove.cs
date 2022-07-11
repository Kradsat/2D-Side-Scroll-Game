using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    Sprite[] characterSprite;

    bool isWalking;
    bool stillWalking;

    float moveSpeed = 5f;

    private void Awake()
    {
        transform.eulerAngles = new Vector2(0,180);
        bool isWalking = false;
        bool stillWalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        //move right
        if(Input.GetKey("right") && !Input.GetKey("left"))
        {
            transform.eulerAngles = new Vector2(0,180);//rotate to the right
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * -moveSpeed * Time.deltaTime, 0f));
        }

        //move left
        else if(Input.GetKey("left") && !Input.GetKey("right"))
        {
            transform.eulerAngles = new Vector2(0,0);//rotate to the left
            if( this.transform.position.x > 0)
            {
                transform.Translate(new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0f));
            }
        }


        //animation
        if(Input.GetKey("right") || Input.GetKey("left"))
        {
            isWalking = true;
            StopCoroutine(Animate());
            StartCoroutine(Animate());
        }
        else
        {
            isWalking = false;
            StopCoroutine(Animate());
            this.GetComponent<SpriteRenderer>().sprite = characterSprite[1];
        }
    }

    //Coroutine for animation
    IEnumerator Animate()
    {
        while(isWalking == true && stillWalking == false)
        {
            stillWalking = true;
            for( int i = 0; i < 4; i++)
            {
                this.GetComponent<SpriteRenderer>().sprite = characterSprite[i];
                yield return new WaitForSeconds(0.3f); 
            }
            stillWalking = false;
        }
    }
}
