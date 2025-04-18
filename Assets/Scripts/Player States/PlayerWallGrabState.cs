using UnityEngine;

public class PlayerWallGrabState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.triggerAnimator("HoldTrigger");
        Time.timeScale = 1f;

        // set gravity to zero to prevent sliding
        player.setGravity(0f);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        // when shift is released, a new state is entered
        if(!Input.GetKey(SettingsTracker.climbKey) && Input.GetAxis("ControllerClimb") == 0)
        {
            // choosing which state to enter
            if (Mathf.Abs(player.getInputX()) > Mathf.Epsilon && player.getTouchingDown())
            {
                // switches player to run state
                player.SwitchState(player.RunState);
            }
            else if (player.getTouchingDown())
            {
                // switches to idle state
                player.SwitchState(player.IdleState);
            }
            else
            {
                // switches player to falling state
                player.SwitchState(player.FallingState);
            }
        }

        // initiates a dash from wall hold
        if (player.getCanDash() && (Input.GetKey(SettingsTracker.dashKey) || Input.GetKey(KeyCode.JoystickButton2)))
        {
            player.SwitchState(player.DashState);
        }

        // switches to wall climb state if vertical input is detected
        if(Mathf.Abs(player.getInputY()) > Mathf.Epsilon)
        {
            player.SwitchState(player.WallClimbState);
        }

        // detects if a jump request is active
        if (Input.GetKeyDown(SettingsTracker.jumpKey) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            // switches to wall jump state
            player.setJumpRequest(false);
            player.SwitchState(player.WallJumpState);
        }

        // detecting if spikes are collided with
        if (player.getTouchingSpikes())
        {
            player.SwitchState(player.DeathState);
        }
    }

    public override void UpdatePhysics(PlayerStateManager player)
    {
        // maintains the player at the same position
        player.setVelocity(new Vector2(0, 0));

        if (player.getTouchingLeft())
        {
            player.setSpriteDirection(true);
        }
        else if (player.getTouchingRight())
        {
            player.setSpriteDirection(false);
        }
    }
}
