using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public int speed = 5;
    public int jumpForce = 5;
    public Rigidbody2D rb;

    private float horizontalInput;
    private float xVel;
    private float yVel;

    // creating an instance of each state
    PlayerBaseState currentState;
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerRunState RunState = new PlayerRunState();
    public PlayerJumpState JumpState = new PlayerJumpState();
    public PlayerFallingState FallingState = new PlayerFallingState();

    void Start()
    {
        // setting the state which the player starts in
        currentState = IdleState;
        currentState.EnterState(this);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // updating the current state's script every frame
        currentState.UpdateState(this);
        currentState.UpdatePhysics(this);

        //detecting horizontal input and character's velocity
        horizontalInput = Input.GetAxis("Horizontal");
        xVel = rb.velocity.x;
        yVel = rb.velocity.y;
    }

    // subroutine which changes the current state
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    // accessor methods for the private variables
    public float getX()
    {
        return xVel;
    }
    public float getY()
    {
        return yVel;
    }
    public float getInput()
    {
        return horizontalInput;
    }
}


