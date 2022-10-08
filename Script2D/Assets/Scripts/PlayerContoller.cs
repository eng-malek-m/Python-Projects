using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    private Rigidbody2D rb2D ;
    private Animator animate;

    private float moveSpeed ;
    private float jumpForce ;
    private bool isJumping ;
    private float moveHorizontal ;
    private float moveVertical ;
    private bool face = false;
    
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animate = gameObject.GetComponent<Animator>();

        moveSpeed = 4f;
        jumpForce = 60F;
        isJumping = false ;

    }

  
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical  = Input.GetAxisRaw("Vertical");
        animate.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        if (moveHorizontal > 0 && !face)

        {
            Flip();
        }
        else if (moveHorizontal < 0 && face)
        {
            Flip();
        }


    }





    void FixedUpdate()
    {

        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed , 0f) , ForceMode2D.Impulse);
        }

        if (!isJumping && moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse); 

        }
    }
        void OnTriggerEnter2D(Collider2D collison)
        {
            if(collison.gameObject.tag == "Platform")

            {
                isJumping = false ;
            
            }
        
        
        }

        void OnTriggerExit2D(Collider2D collison)
        {
            if (collison.gameObject.tag == "Platform")
            {
                isJumping = true;
            }
        }

        void Flip()
        {
            face = !face;

            Vector2 currentMove = transform.localScale;
            currentMove.x *= -1;
            transform.localScale = currentMove;
        
        
        }
    
    }


    

    


