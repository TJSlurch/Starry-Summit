using UnityEngine;

public class PlayerRunState : PlayerBaseState
{

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Run State");
    }

    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        // detects for no horizontal input
        if (Mathf.Abs(player.getInputX()) < Mathf.Epsilon && player.getTouchingDown())
        {
            // switches to idle state
            player.SwitchState(player.IdleState);
        }

        // detects if vertical velocity is negative (downwards)
        if (player.getY() < -0.01 && !player.getTouchingDown())
        {
            // switches player to falling state
            player.SwitchState(player.FallingState);
        }

        // detects if a jump request is active
        if (player.getJumpRequest())
        {
            // switches to jump state
            player.SwitchState(player.JumpState);
            player.setJumpRequest(false);
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
        // detects horizontal input and uses it to change player velocity
        player.setVelocity(new Vector2(player.getInputX() * player.getSpeed(), player.getY()));
    }
}





