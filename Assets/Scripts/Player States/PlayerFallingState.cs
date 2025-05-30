using UnityEngine;
using System.Collections;

public class PlayerFallingState : PlayerBaseState
{
    private float fallMultiplier = 4f;
    private float weightlessGravity = 2f;

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        player.triggerAnimator("FallTrigger");
        Time.timeScale = SettingsTracker.AerialAidMultiplier;
    }

    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        // detects if horizontal input isn't zero
        if (Mathf.Abs(player.getX()) > Mathf.Epsilon && player.getTouchingDown())
        {
            // switches player to run state
            player.SwitchState(player.RunState);
            // waits briefly to prevent dash spam
            player.StartCoroutine(waitSeconds(0.25f, player));
            player.setCanDash(true);
        }
        // detects if player is touching the ground
        else if (player.getTouchingDown())
        {
            // switches to idle state
            player.SwitchState(player.IdleState);
            // waits briefly to prevent dash spam
            player.StartCoroutine(waitSeconds(0.25f, player));
            player.setCanDash(true);
        }

        // initiates a dash if arrow keys are pressed whilst a dash is possible
        if (player.getCanDash() && (Input.GetKey(SettingsTracker.dashKey) || Input.GetKey(KeyCode.JoystickButton2)))
        {
            player.SwitchState(player.DashState);
        }

        // detects if wall grab button is pressed whilst next to a wall
        if ((player.getTouchingLeft() || player.getTouchingRight()) && (Input.GetKey(SettingsTracker.climbKey) || Input.GetAxis("ControllerClimb") != 0))
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
        if (player.getY() > -1)
        {
            player.setGravity(weightlessGravity);
        }
        // gravity is then increased to a maximum as the jump ends
        else
        {
            player.setGravity(fallMultiplier);
        }


        // detects horizontal input and uses it to change player velocity
        if (Mathf.Abs(player.getInputX()) > 0)
        {
            player.setVelocity(new Vector2(player.getInputX() * player.getSpeed(), player.getY()));
        }
        else
        {
            player.setVelocity(new Vector2(0, player.getY()));
        }

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

    // Wait seconds coroutine which prevents dashing from being enabled immediately
    public IEnumerator waitSeconds(float time, PlayerStateManager player)
    {
        yield return new WaitForSeconds(0.25f);
    }
}
