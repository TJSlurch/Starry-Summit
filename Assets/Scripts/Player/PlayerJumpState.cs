using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private float lowJumpMultiplier = 3.5f;
    private float regularGravity = 2f;
    private float weightlessGravity = 1f;

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Jump State");
        // initiates a jump as soon as this state is switched to
        player.setVelocity(new Vector2(player.getX(), player.getJumpForce()));
    }

    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        // detects if vertical velocity is negative (downwards)
        if (player.getY() < -0.1)
        {
            // switches player to falling state
            player.SwitchState(player.FallingState);
        }

        // initiates a dash if arrow keys are pressed whilst a dash is possible
        if ((Mathf.Abs(Input.GetAxis("dashY")) > Mathf.Epsilon || Mathf.Abs(Input.GetAxis("dashX")) > Mathf.Epsilon) & player.getCanDash())
        {
            player.SwitchState(player.DashState);
        }

        // detects if wall grab button is pressed whilst next to a wall
        if ((player.getTouchingLeft() || player.getTouchingRight()) && Input.GetKey(KeyCode.LeftShift))
        {
            player.SwitchState(player.WallGrabState);
        }
    }

    // what happens every frame whilst this state is active
    public override void UpdatePhysics(PlayerStateManager player)
    {
        // at the peak of the player's jump, they experience reduced gravity
        if (player.getY() < 1)
        {
            player.setGravity(weightlessGravity);
        }
        // if space is held, gravity remains constant for a normal jump
        else if (Input.GetKey(KeyCode.Space))
        {
            player.setGravity(regularGravity);
        }
        // if space is released, gravity is increased for a shorter jump
        else
        {
            player.setGravity(lowJumpMultiplier);
        }
        // detects horizontal input and uses it to change player velocity
        player.setVelocity(new Vector2(player.getInputX() * player.getSpeed(), player.getY()));
    }
}
