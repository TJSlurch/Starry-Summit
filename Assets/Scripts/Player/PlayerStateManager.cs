using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    // declare variables and declare initial values
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpForce = 12f;
    private float horizontalInput;
    private bool jumpRequest = false;
    private Rigidbody2D rb;

    // creating an instance of each state
    PlayerBaseState currentState;
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerRunState RunState = new PlayerRunState();
    public PlayerJumpState JumpState = new PlayerJumpState();
    public PlayerFallingState FallingState = new PlayerFallingState();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // setting the state which the player starts in
        currentState = IdleState;
        currentState.EnterState(this);
    }

    void Update()
    {
        // updating the update methods for the current state's script
        currentState.UpdateState(this);
        currentState.UpdatePhysics(this);

        // detecting horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        // detecing a space bar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequest = true;
            StartCoroutine(ResetJump());
        }
    }

    // cooroutine sets the jump request boolean to false after 0.5s
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
    }

    // accessor methods for the private attributes
    public float getInput()
    {
        return horizontalInput;
    }
    public float getSpeed()
    {
        return speed;
    }
    public float getJumpForce()
    {
        return jumpForce;
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
}

