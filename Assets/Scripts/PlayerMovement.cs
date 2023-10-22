using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Planets")] public GameObject[] planets;
    public float gravityFactor=0.5f;
    
    [Header("Movement")] public float moveSpeed;

    public float groundDrag;

    public float jumpForce= 5f;
    public float jumpCooldown;
    public float airMultiplier;
    private bool readyToJump = true;
    
    [Header("Key binds")]
    public KeyCode jumpKey = KeyCode.Space;
    
    [Header("Ground Check")] public float playerHeight;
    public LayerMask whatIsGround;
    private bool grounded;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;
    
    Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
    }
    
    private void Update()
    {
        // Direction
        Vector3 normalDirection = planets[0].transform.position - transform.position;
        // Update gravity with first planet
        Physics.gravity = normalDirection * gravityFactor;
        
        // Rotate with gravity direction
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, -Physics.gravity) * transform.rotation;
        transform.rotation = targetRotation;
        // Rotate each child object to keep them upright
        
        // ground check with direction to the center of the planet.
        //
        grounded = Physics.Raycast(transform.position, normalDirection, playerHeight * 0.5f + 0.25f, whatIsGround);
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0f;
        }
        
        MyInput();
        SpeedControl();
        
    }
    
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
        // When to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            
            Jump();
            
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        // on ground
        if(grounded)
        {
            rb.AddForce(moveDirection.normalized * (moveSpeed * 10f), ForceMode.Force);
        } else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * (moveSpeed * 10f * airMultiplier), ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(0f, 0f, 0f);
        
        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        Debug.Log("Jumping");
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        // calculate normal direction taking the position of the planet minus the player
        Vector3 normalDirection = (transform.position - planets[0].transform.position).normalized;
        rb.AddForce(normalDirection * jumpForce, ForceMode.Impulse);
    }
    
    private void ResetJump()
    {
        readyToJump = true;
    }
}
