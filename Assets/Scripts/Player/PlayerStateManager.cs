using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public int speed = 5;
    public int jumpForce = 5;
    public float horizontalInput;
    public Rigidbody2D rb;

    public float x;
    public float y;

    // instantiating an instance of each state
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
        horizontalInput = Input.GetAxis("Horizontal");

        x = rb.velocity.x;
        y = rb.velocity.y;
    }

    // subroutine which changes the current state
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}


