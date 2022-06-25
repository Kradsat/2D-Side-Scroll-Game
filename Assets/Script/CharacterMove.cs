using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("right") && !Input.GetKey("left"))
        {
            transform.eulerAngles = new Vector2(0,180);
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * -moveSpeed * Time.deltaTime, 0f));
        }
        else if(Input.GetKey("left") && !Input.GetKey("right"))
        {
            transform.eulerAngles = new Vector2(0,0);
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0f));
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Dupe1")
        {
            Debug.Log("Crash");
            Collider2D otherCollider = other.GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(otherCollider, GetComponent<Collider2D>());
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Dupe1")
        {
            Debug.Log("Out");
            Collider2D otherCollider = other.GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(otherCollider, GetComponent<Collider2D>());
        }
    }
}
