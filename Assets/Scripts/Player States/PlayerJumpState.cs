using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private float lowJumpMultiplier = 11f;
    private float regularGravity = 5f;
    private float weightlessGravity = 2f;

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Jump State");
        player.triggerAnimator("JumpTrigger");
        player.playJump();
        Time.timeScale = SettingsTracker.AerialAidMultiplier;

        player.setJumpRequest(false);

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
        // at the peak of the player's jump, they experience reduced gravity
        if (player.getY() < 1)
        {
            player.setGravity(weightlessGravity);
        }
        // if space is held, gravity remains constant for a normal jump
        else if (Input.GetKey(SettingsTracker.jumpKey))
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

        // flips sprite depending on direction
        if (player.getX() < 0)
        {
            player.setSpriteDirection(true);
        }
        else if (player.getX() > 0)
        {
            player.setSpriteDirection(false);
        }
    }
}
