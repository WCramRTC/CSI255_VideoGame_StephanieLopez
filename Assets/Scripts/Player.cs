using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stephanie Lopez
public class NewBehaviourScript1 : MonoBehaviour
{
    public int PlayerSpeed = 10;
    public bool PlayerFacingRight = true;
    public int JumpDistance = 150;
    public float movementX;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void PlayerMovement ()
    {
        //Movement controls
        movementX = Input.GetAxis("Horizontal");

        //Animations

        //Player Facing Direction
        if (movementX > 0.0f && !PlayerFacingRight)
        {
            FlipPlayer();
        }
        else if (movementX < 0.0f && PlayerFacingRight)
        {
            FlipPlayer();
        }

        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movementX * PlayerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //Code for jumping
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpDistance));
    }
    
    void FlipPlayer()
    {
        PlayerFacingRight = !PlayerFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
