using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConnectWithGroundTest : MonoBehaviour
{

    [SerializeField]
    bool isGrounded = false;
    Rigidbody2D rb;
    public int jumpForce;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")) {
            if(isGrounded) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Gets the layer of the item you collide with as an int
        int layerNumber = other.gameObject.layer;
        // Converts that number to the layer name
        int layerMaskLayer = layerMask.value;
        

        // Checks if the layer is a ground. Set to true if it's not
        if(layerNumber == layerMaskLayer) {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        
        // When the object LEAVES the collsion ( here jumping off the ground)
        // Turn is ground to off
        if(LayerMask.LayerToName(other.gameObject.layer) == "Ground") {
            isGrounded = false;
        }
    }

    
}
