using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stephanie Lopez
public class Player : MonoBehaviour
{
    public int PlayerSpeed = 10;
    public bool PlayerFacingRight = true;
    public int JumpDistance = 150;
    public float movementX;

    private bool canJump = true; // Follows if player may jump
    private bool isGrounded = false; // Tracks whether the player is grounded

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded using raycasting
        // raycasting may be used for collision detection orobject interaction.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, LayerMask.GetMask("Ground"));

        // If the raycast hits an object with a BoxCollider2D underneath the player, allow jumping
        isGrounded = hit.collider != null;

        // Allow the player to jump only when grounded and canJump is true
        if (isGrounded && canJump && Input.GetButtonDown("Jump"))
        {
            Jump();
            canJump = false; // Created canJump to prevent double jumping
        }

        PlayerMovement();
    }

    void PlayerMovement()
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