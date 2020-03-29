using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    private bool movement_Right = false;
    private bool movement_Left = false;
    private bool movement_Forward = false;
    private bool movement_Backwards = false;
    private bool movement_Jump = false;

    private const float position_MaxJump = 5;

    public const float movement_MaxVelocityLateral = 3;
    public const float movement_MaxVelocityForward = 10;
    public const float movement_MaxVelocityUp = 3;

    public float movement_LateralVelocity = 0;
    public float movement_ForwardVelocity = 0;
    public float movement_UpwardVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = true;
    }

    void FixedUpdate()
    {
        Vector3 cubeVelocity = rb.velocity;
        if(movement_Right && cubeVelocity.x < movement_MaxVelocityLateral)
        {
            rb.AddForce(500 * Time.fixedDeltaTime, 0 ,0);
        }
        if(movement_Forward && cubeVelocity.z < movement_MaxVelocityForward)
        {
            rb.AddForce(0, 0 ,500 * Time.fixedDeltaTime);
        }
        if(movement_Left && cubeVelocity.x > -movement_MaxVelocityLateral)
        {
            rb.AddForce(-500 * Time.fixedDeltaTime, 0 ,0);
        }
        if(movement_Backwards && cubeVelocity.z > -movement_MaxVelocityLateral)
        {
            rb.AddForce(0, 0 ,-500 * Time.fixedDeltaTime);
        }
        if(movement_Jump && rb.position.y < position_MaxJump && cubeVelocity.y < movement_MaxVelocityUp)
        {
            rb.AddForce(0,1000 * Time.fixedDeltaTime ,0);
        }

        movement_LateralVelocity = rb.velocity.x;
        movement_ForwardVelocity = rb.velocity.z;
        movement_UpwardVelocity = rb.velocity.y;
    }

    // Update is called once per frame
    void Update()
    {
        cubeMovementUpdate();
    }

    void cubeMovementUpdate()
    {
        if(Input.GetKey("space"))
        {
            movement_Jump = true;
        }
        else
        {
            movement_Jump = false;
        }

        if(Input.GetKey("d"))
        {
            movement_Right = true;
        }
        else
        {
            movement_Right = false;
        }

        if(Input.GetKey("w"))
        {
            movement_Forward = true;
        }
        else
        {
            movement_Forward = false;
        }

        if(Input.GetKey("a"))
        {
            movement_Left  = true;
        }
        else
        {
            movement_Left = false;
        }

        if(Input.GetKey("s"))
        {
            movement_Backwards = true;
        }
        else
        {
            movement_Backwards = false;
        }
    }
}
