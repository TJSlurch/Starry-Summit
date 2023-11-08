using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Idle State");
        player.triggerAnimator("IdleTrigger");

        // sets velocity to 0 as soon as no input is detected
        player.setVelocity(new Vector2(0, player.getY()));
    }

    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        // detects if a jump request is active
        if (player.getJumpRequest())
        {
            // switches to jump state
            player.setJumpRequest(false);
            player.SwitchState(player.JumpState);
        }

        // detects if vertical velocity is negative (downwards)
        if (player.getY() < -0.01 && !player.getTouchingDown())
        {
            // switches player to falling state
            player.SwitchState(player.FallingState);
        }

        // detects if horizontal input isn't zero
        if (Mathf.Abs(player.getInputX()) > Mathf.Epsilon && player.getTouchingDown())
        {
            // switches player to run state
            player.SwitchState(player.RunState);
        }

        // initiates a dash if arrow keys are pressed whilst a dash is possible
        if (player.getCanDash() && (Input.GetAxis("Dash") > 0 ))
        {
            player.SwitchState(player.DashState);
        }

        // detects if wall grab button is pressed whilst next to a wall
        if ((player.getTouchingLeft() || player.getTouchingRight()) && Input.GetAxis("Wall Hold") > 0)
        {
            player.SwitchState(player.WallGrabState);
        }
    }

    // no movement occurs during idle state, so physics don't need updating, only the visual crouch
    public override void UpdatePhysics(PlayerStateManager player)
    {
        // pressing down sets the crouch animation to true
        if (player.getInputY() < 0)
        {
            player.setSpriteCrouch(true);
        }
        else
        {
            player.setSpriteCrouch(false);
        }
    }
}