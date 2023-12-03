using UnityEngine;

public class PlayerRunState : PlayerBaseState
{

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Run State");
        player.triggerAnimator("RunTrigger");
        player.playRun();
        player.setGravity(8f);
        Time.timeScale = 1f;
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
            player.setJumpRequest(false);
            player.SwitchState(player.JumpState);
        }

        // initiates a dash if arrow keys are pressed whilst a dash is possible
        if (player.getCanDash() && Input.GetKey(SettingsTracker.dashKey))
        {
            player.SwitchState(player.DashState);
        }

        // detects if wall grab button is pressed whilst next to a wall
        if ((player.getTouchingLeft() || player.getTouchingRight()) && Input.GetKey(SettingsTracker.climbKey))
        {
            player.SwitchState(player.WallGrabState);
        }

        // detecting if spikes are collided with
        if (player.getTouchingSpikes())
        {
            player.SwitchState(player.DeathState);
        }
    }

    // what happens every frame whilst this state is active
    public override void UpdatePhysics(PlayerStateManager player)
    {
        // detects horizontal input and uses it to change player velocity
        player.setVelocity(new Vector2(player.getInputX() * player.getSpeed(), player.getY()));

        // flips the sprite depending on direction
        if(player.getX() < 0)
        {
            player.setSpriteDirection(true);
        }
        else if(player.getX() > 0)
        {
            player.setSpriteDirection(false);
        }
    }
}





