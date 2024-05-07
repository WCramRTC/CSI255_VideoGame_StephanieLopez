using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;
    public int jumpForce = 5;
    public LayerMask layerMask;
    public float distanceToGround = 2.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit;


        Vector2 rayStart = transform.position;
        Vector2 rayDirection = Vector2.down;

        
        hit = Physics2D.Raycast(rayStart, rayDirection, distanceToGround);

        if(hit) {
            Debug.Log(hit.collider.gameObject.layer);
        }

        if(Input.GetButtonDown("Jump")) {
            Debug.DrawRay(rayStart, rayDirection, Color.red);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }
}
