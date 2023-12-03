using UnityEngine;

public class PlayerWallClimbState : PlayerBaseState
{
    private int previousClimbDirection;

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Wall Climb State");
        player.triggerAnimator("ClimbTrigger");
        player.playClimb();
        Time.timeScale = 1f;
    }
    public override void UpdateState(PlayerStateManager player)
    {
        // when shift is released, a new state is entered
        if (!Input.GetKey(SettingsTracker.climbKey))
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

        // initiates a dash from wall climb
        if (player.getCanDash() && Input.GetKey(SettingsTracker.dashKey))
        {
            player.SwitchState(player.DashState);
        }

        // switches back to wall grab state if no vertical velocity is detected
        if (Mathf.Abs(player.getInputY()) < Mathf.Epsilon)
        {
            player.SwitchState(player.WallGrabState);
        }

        // detects if a wall jump request is active, or if top of wall is reached
        if (Input.GetKeyDown(SettingsTracker.jumpKey) || (previousClimbDirection == 1 && !player.getTouchingLeft() && !player.getTouchingRight()))
        {
            // switches to jump state
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
        // if the player is touching the wall, update the value
        if (player.getTouchingLeft() || player.getTouchingRight())
        {
            // if player is climbing upward
            if (player.getInputY() > 0)
            {
                previousClimbDirection = 1;
            }
            // if player is climbing downward
            else if (player.getInputY() < 0)
            {
                previousClimbDirection = -1;
            }
        }

        // if touching wall, the player can move as usual
        // if last climbed direction was down and the player is inputting up, allow movement
        if ((player.getTouchingLeft() || player.getTouchingRight()) || (previousClimbDirection == -1 && player.getInputY() > 0))
        {
            player.setVelocity(new Vector2(0, player.getInputY() * player.getClimbSpeed()));
        }
        else
        {
            player.setVelocity(new Vector2(0, 0));
        }

        // flips the sprite depending on direction
        if (player.getTouchingLeft())
        {
            player.setSpriteDirection(true);
        }
        else if(player.getTouchingRight())
        {
            player.setSpriteDirection(false);
        }
    }
}
