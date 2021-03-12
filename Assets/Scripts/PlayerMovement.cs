using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem ps;

    //movement
    private Rigidbody2D rb;
    public float runSpeed;
    public float jumpForce;
    private float moveInput;

    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;
    public float groundTimer;
    public float groundTimeToReset;

    //time freeze
    public PlayerCheck playerCheck;
    public GameObject rememberPosition;
    public PlayerLeftLPP playerLeftLPP;
    public Dialogue dialogue;
    public SceneManagerer sceneManagerer;
    public GameObject ghostPlayer;
    public ProcessingEpic processing;
    public bool freezeTime;
    public float freezeCounter;
    public float freezeResetTime;
    public bool coolDownIsActive = false;
    //public float processingIntensity;
    //public float processingIntensityDefault;
    public float saturation;
    public float defaultSat = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        ps = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        ghostPlayer.SetActive(false);
        processing.GhostMode(defaultSat);

        freezeCounter = freezeResetTime;
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);

        if (moveInput < -0.1)
        {
            Flip(true);
        }
        if (moveInput > 0.1)
        {
            Flip(false);
        }
    }

    void Flip(bool isFacingRight)
    {
        if (isFacingRight == true)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (isFacingRight == false)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    void Update()
    {

        //----------------------------------------MOVEMENT----------------------------------------

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

        //----------------------------------------TIME FREEZE----------------------------------------

        if (Input.GetKeyDown(KeyCode.Mouse0) && freezeTime == true) //dissable freezetime
        {
            freezeTime = false;
            coolDownIsActive = true;
            freezeCounter = freezeResetTime;
            playerCheck.ChangeCollider(false);
            rememberPosition.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Invoke("CoolDown", 1f);
            ghostPlayer.SetActive(false);
            processing.GhostMode(defaultSat);
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && freezeTime == false && coolDownIsActive == false) //active freezetime
        {
            if(dialogue.inDialogue == false || sceneManagerer.isPaused == false)
            {
                RememberPlayerPos();
                freezeTime = true;
                playerCheck.ChangeCollider(false);
                playerLeftLPP.ChangeLayer(1);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                ghostPlayer.SetActive(true);
                processing.GhostMode(saturation);
                ps.Play();
                ps.transform.position = transform.position;
                ParticleSystem.EmissionModule em = ps.emission;
                em.enabled = true;
            }
        }

        if (freezeTime == true)
        {
            freezeCounter -= Time.deltaTime;
            if (freezeCounter <= 0)
            {
                freezeTime = false;
                freezeCounter = freezeResetTime;
                SendPlayerBack();
                playerCheck.ChangeCollider(false);
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                ghostPlayer.SetActive(false);
                processing.GhostMode(defaultSat);
            }
        }
    }

    public void CoolDown()
    {
        coolDownIsActive = false;
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