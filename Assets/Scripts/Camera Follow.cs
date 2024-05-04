using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Stephanie Lopez

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; // Coordinates of camera

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void LateUpdate() //It is under LateUpdate instead of update to ensure that when the player moves the position is applied in frames. 
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);

            transform.position = desiredPosition;
        }
    }
}