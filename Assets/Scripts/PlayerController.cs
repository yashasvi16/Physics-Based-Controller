using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector3 groundCheckOffset;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundCheckRadius;
    [SerializeField] Transform camHolder;
    Rigidbody rb;
    Vector2 move, look;
    Quaternion targetDirection;
    Animator animator;
    //public Transform orientation;
    //public Transform player;
    //public Transform playerObj;
    float sprint;
    float jump;
    float jumpSpeed;
    float jumpTimeOut = 1f;
    float jumpTimeOutDelta;
    float fallTimeOut = 0.15f;
    float fallTimeOutDelta;
    float ySpeed;

    [SerializeField]
    float speed = 5f, sensitivity, jumpHeight;
    bool isGrounded;
    float lookRotation;
    float turnSmoothVelocity;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        sprint = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jump = context.ReadValue<float>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Cursor.visible = false;
    }

    private void Update()
    {
        Move();
        IsGrounded();
        Jump();
    }

    private void Move()
    {
        float horizontal = move.x;
        float vertical = move.y;

        float targetSpeed;
        targetSpeed = sprint == 0 ? speed : speed * 2.5f;

        if(!isGrounded)
        {
            ySpeed += Physics.gravity.y * Time.deltaTime;
            animator.SetBool("isGrounded", false);
        }
        else
        {
            ySpeed = 0f;
            animator.SetBool("isGrounded", true);
        }

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);
        moveDirection = camHolder.forward * moveDirection.z + camHolder.right * moveDirection.x;
        moveDirection.y = 0;
        moveDirection = moveDirection.normalized;
        var velocity = targetSpeed * moveDirection;
        velocity.y = ySpeed;
        transform.Translate(velocity * Time.deltaTime + new Vector3(0f, jumpSpeed, 0f) * Time.deltaTime, Space.World);

        if (moveDirection.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.y) * Mathf.Rad2Deg + camHolder.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * sensitivity);
        }
        float currentSpeed = velocity.magnitude;
        animator.SetFloat("Speed", currentSpeed, 0.25f, Time.deltaTime);
    }

    private void IsGrounded()
    {
        isGrounded = Physics.CheckSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius, groundMask);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            fallTimeOutDelta = fallTimeOut;

            if (jumpSpeed <= 0f)
            {
                jumpSpeed = 0f;
            }

            if (jump != 0 && jumpTimeOutDelta <= 0f)
            {
                jumpSpeed = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
                animator.SetBool("Jump", true);
            }

            if (jumpTimeOutDelta >= 0f)
            {
                jumpTimeOutDelta -= Time.deltaTime;
            }
        }
        else
        {
            jumpTimeOutDelta = jumpTimeOut;

            if(fallTimeOutDelta >= 0f)
            {
                fallTimeOutDelta -= Time.deltaTime;
            }

            animator.SetBool("Jump", false);
        }

        if (jumpSpeed < 50f && !isGrounded)
        {
            jumpSpeed += Physics.gravity.y * 2f * Time.deltaTime;
        }
    }

}
