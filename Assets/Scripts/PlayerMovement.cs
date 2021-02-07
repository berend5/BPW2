using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //movemenent
    private Rigidbody2D rb;
    public float runSpeed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;
    public float groundTimer;
    public float groundTimeToReset;

    //time freeze
    public GameObject rememberPosition;
    public bool freezeTime;
    public float freezeCounter;
    public float freezeResetTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
    }

    void Update()
    {
        if (Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround))
        {
            groundTimer = groundTimeToReset;
            isGrounded = true;
        }
        else
        {
            groundTimer -= Time.deltaTime;
            if (groundTimer <= 0)
            {
                isGrounded = false;
            }
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.W) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && freezeTime == false)
        {
            RememberPlayerPos();
            freezeTime = true;
            freezeCounter = freezeResetTime;
            Debug.Log("freezetime started");
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && freezeTime == true)
        {
            freezeTime = false;
            freezeCounter = freezeResetTime;
            Debug.Log("freezetime canceled");
        }

        if (freezeTime == true)
        {
            freezeCounter -= Time.deltaTime;
            if (freezeCounter <= 0)
            {
                freezeTime = false;
                SendPlayerBack();
                Debug.Log("freezetime ended");
            }
        }
    }

    void RememberPlayerPos()
    {
        rememberPosition.SetActive(true);
        rememberPosition.transform.position = new Vector2(transform.position.x, transform.position.y);
        rememberPosition.transform.rotation = Quaternion.identity;
    }

    void SendPlayerBack()
    {
        transform.position = new Vector2(rememberPosition.transform.position.x, rememberPosition.transform.position.y);
        transform.rotation = Quaternion.identity;
        rememberPosition.SetActive(false);
    }
}