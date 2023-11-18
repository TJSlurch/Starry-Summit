using System.Collections;
using System;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    // declare variables and declare initial values
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float climbSpeed = 5f;
    private bool jumpRequest = false;
    private bool canDash = true;

    // define the components which are to be used
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private BoxCollider2D rbRight;
    private BoxCollider2D rbLeft;
    private BoxCollider2D rbDown;
    [SerializeField] private GameObject RightCollision;
    [SerializeField] private GameObject LeftCollision;
    [SerializeField] private GameObject DownCollision;
    [SerializeField] private PlayerLocationTracker tracker;

    // declare the sound effects
    [SerializeField] private AudioSource runAS;
    [SerializeField] private AudioSource jumpAS;
    [SerializeField] private AudioSource dashAS;
    [SerializeField] private AudioSource climbAS;
    [SerializeField] private AudioSource deathAS;


    // creating an instance of each state
    private PlayerBaseState currentState;
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerRunState RunState = new PlayerRunState();
    public PlayerJumpState JumpState = new PlayerJumpState();
    public PlayerFallingState FallingState = new PlayerFallingState();
    public PlayerDashState DashState = new PlayerDashState();
    public PlayerWallGrabState WallGrabState = new PlayerWallGrabState();
    public PlayerWallClimbState WallClimbState = new PlayerWallClimbState();
    public PlayerWallJumpState WallJumpState = new PlayerWallJumpState();
    public PlayerDeathState DeathState = new PlayerDeathState();

    void Start()
    {
        // using getComponent to retreive the components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rbRight = RightCollision.GetComponent<BoxCollider2D>();
        rbLeft = LeftCollision.GetComponent<BoxCollider2D>();
        rbDown = DownCollision.GetComponent<BoxCollider2D>();

        // setting the state which the player starts in
        currentState = IdleState;
        currentState.EnterState(this);
    }

    void Update()
    {
        // updating the UpdateState method for the current state's script
        currentState.UpdateState(this);    

        // detecing a space bar input
        if (Input.GetAxis("Jump") > 0)
        {
            jumpRequest = true;
            StartCoroutine(ResetJump());
        }
    }

    // Fixed Update is more reliable for movement related updates
    private void FixedUpdate()
    {
        // updating the UpdateState method for the current state's script
        currentState.UpdatePhysics(this);
    }

    // cooroutine sets the jump request boolean to false after 0.3s
    private IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(0.3f);
        jumpRequest = false;
    }
    

    // subroutine which changes the current state
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
        // stop looping sound effects
        climbAS.Stop();
        runAS.Stop();
    }

    // called when the player needs to reset position
    public void ResetToCheckpoint()
    {
        // sets to the checkpoint position from PlayerLocationTracker
        transform.position = new Vector2(tracker.getRespawnX(), tracker.getRespawnY());
    }

    // accessor methods for the private attributes
    public float getInputX()
    {
        return Input.GetAxis("Horizontal");
    }
    public float getInputY()
    {
        return Input.GetAxis("Vertical");
    }
    public float getSpeed()
    {
        return speed;
    }
    public float getJumpForce()
    {
        return jumpForce;
    }
    public float getClimbSpeed()
    {
        return climbSpeed;
    }
    public float getX()
    {
        return rb.velocity.x;
    }
    public float getY()
    {
        return rb.velocity.y;
    }
    public bool getJumpRequest()
    {
        return jumpRequest;
    }
    public bool getCanDash()
    {
        return canDash;
    }
    public bool getTouchingRight()
    {
        return rbRight.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
    public bool getTouchingLeft()
    {
        return rbLeft.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
    public bool getTouchingDown()
    {
        return rbDown.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
    public bool getTouchingSpikes()
    {
        return rb.IsTouchingLayers(LayerMask.GetMask("Spikes"));
    }

    // mutator methods for the private attributes
    public void setVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
    public void setGravity(float multiplier)
    {
        rb.gravityScale = multiplier;
    }
    public void setJumpRequest(bool value)
    {
        jumpRequest = value;
    }
    public void setCanDash(bool value)
    {
        canDash = value;
    }
    public void triggerAnimator(string trigger)
    {
        animator.SetTrigger(trigger);
    }
    public void setSpriteDirection(bool direction)
    {
        sprite.flipX = direction;
    }
    public void setSpriteCrouch(bool value)
    {
        animator.SetBool("Crouched?", value);
    }

    // public methods to play sound effects
    public void playRun()
    {
        runAS.Play();
    }
    public void playJump()
    {
        jumpAS.Play();
    }
    public void playDash()
    {
        dashAS.Play();
    }
    public void playClimb()
    {
        climbAS.Play();
    }
    public void playDeath()
    {
        deathAS.Play();
    }
}

