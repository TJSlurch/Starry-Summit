using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    // declare variables and declare initial values
    public float speed = 5f;
    public float jumpForce = 5f;
    public Rigidbody2D rb;
    private float horizontalInput;
    public bool jumpRequest = false;

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

        // detecting horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        // detecing a space bar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequest = true;
            StartCoroutine(ResetJump());
        }
    }

    // sets the jump request boolean to false after 0.5s
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

    public float getInput()
    {
        return horizontalInput;
    }
}


