using System.Collections;
using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    private float dashSpeed = 40f;
    private float dashTime = 0.15f;                            

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Dash State");
        player.triggerAnimator("DashTrigger");
        player.playDash();

        player.setCanDash(false);

        // sets gravity to zero and launches player in the direction inputted 
        player.setGravity(0f);
        if (player.getInputX() != 0 || player.getInputY() != 0)
        {
            player.setVelocity(new Vector2(RoundAwayFromZero(player.getInputX()), RoundAwayFromZero(player.getInputY())).normalized * dashSpeed);
        }
        else
        {
            // if no input, dashes right as default
            player.setVelocity(new Vector2(1, 0).normalized * dashSpeed);
        }

        // starts the process of ending the dash
        player.StartCoroutine(endDash(dashTime, player));
    }

    // coroutine which resets the player's movement
    public IEnumerator endDash(float time, PlayerStateManager player)
    {
        // waits for the length of the dash
        yield return new WaitForSeconds(time);

        // resets gravity
        player.setGravity(5f);
        // resets horizontal and vertical velocity if going upwards
        if(player.getY() > -5)
        {
            player.setVelocity(new Vector2(0, 0));
        }

        // detects if touching ground with input
        if (Mathf.Abs(player.getInputX()) > Mathf.Epsilon && player.getTouchingDown() && !player.getTouchingSpikes())
        {
            // switches player to run state
            player.SwitchState(player.RunState);
            // waits briefly to prevent dash spamming
            yield return new WaitForSeconds(0.25f);
            player.setCanDash(true);
        }
        else if(player.getTouchingDown() && !player.getTouchingSpikes())
        {
            // switches to idle state
            player.SwitchState(player.IdleState);
            // waits briefly to prevent dash spamming
            yield return new WaitForSeconds(0.25f);
            player.setCanDash(true);
        }
        else if(!player.getTouchingSpikes())
        {
            // switches player to falling state
            player.SwitchState(player.FallingState);
        }
    }

    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        // detects if wall grab button is pressed whilst dashing into a wall
        if (player.getTouchingLeft() && player.getX() < 0 && (Input.GetKey(SettingsTracker.climbKey) || Input.GetAxis("ControllerClimb") != 0))
        {
            player.SwitchState(player.WallGrabState);
        }
        // detects if wall grab button is pressed whilst dashing into a wall
        if (player.getTouchingRight() && player.getX() > 0 && (Input.GetKey(SettingsTracker.climbKey) || Input.GetAxis("ControllerClimb") != 0))
        {
            player.SwitchState(player.WallGrabState);
        }

        // detecting if spikes are collided with
        if (player.getTouchingSpikes())
        {
            player.SwitchState(player.DeathState);
        }
    }

    // no movement occurs during idle state, so physics don't need updating
    public override void UpdatePhysics(PlayerStateManager player)
    {
        // flips sprite depending on direction
        if (player.getX() < 0)
        {
            player.setSpriteDirection(true);
        }
        else
        {
            player.setSpriteDirection(false);
        }
    }

    // function to round values away from zero
    private float RoundAwayFromZero(float value)
    {
        // if negative, rounds down
        if (value >= 0)
        {
            return Mathf.Ceil(value);
        }
        // if positive, round up
        else if (value <= 0)
        {
            return Mathf.Floor(value);
        }
        // if zero, return zero
        else
        {
            return 0f;
        }
    }

}


