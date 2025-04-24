using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Transform orientation;
    public float horizontalInput;
    public float verticalInput;
    public float playerHeight;
    public LayerMask isGround;
    bool Grounded;
    public float groundDrag;
    public Transform groundCheck;
    public float groundCheckRadius = 0.4f;
    private float runSpeed;
    public Transform playerParent;

    Vector3 moveDirection;

    public Animator animator;

    public Rigidbody rb;

    private void Update()
    {
        MyInput();
        UpdateAnimator();

        Grounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, isGround);

        if (!Input.anyKey)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            rb.drag = 0;
        }
        
        if(moveDirection == Vector3.zero)
        {
            animator.SetFloat("Speed", 0); 
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("Speed", 0.5f);
        }
        else
        {
            animator.SetFloat("Speed", 1);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        rb.freezeRotation = true;

        this.transform.position = playerParent.transform.position;
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        float currentSpeed = movementSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= 2f;
        }

        rb.velocity = moveDirection.normalized * currentSpeed;
    }

    private void UpdateAnimator()
    {
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0f;
        float speed = horizontalVelocity.magnitude;

        float normalizedSpeed = Mathf.Clamp01(speed / runSpeed);

        animator.SetFloat("Speed", normalizedSpeed);
    }


}
