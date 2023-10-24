using System.Collections;
using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    private float dashSpeed = 30f;
    private float dashTime = 0.15f;

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Dash State");
        player.setCanDash(false);

        // sets gravity to zero and launches player in the direction inputted
        player.setGravity(0f);
        player.setVelocity(new Vector2(Input.GetAxis("dashX"), Input.GetAxis("dashY")) * dashSpeed);

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
        // resets vertical velocity if going upwards
        if(player.getY() > 0.01)
        {
            player.setVelocity(new Vector2(player.getX(), 0));
        }

        // detects if touching ground with input
        if (Mathf.Abs(player.getInput()) > Mathf.Epsilon && player.getTouchingDown())
        {
            // switches player to run state
            player.SwitchState(player.RunState);
            // waits briefly to prevent dash spamming
            yield return new WaitForSeconds(0.25f);
            player.setCanDash(true);
        }
        else if(player.getTouchingDown())
        {
            // switches to idle state
            player.SwitchState(player.IdleState);
            // waits briefly to prevent dash spamming
            yield return new WaitForSeconds(0.25f);
            player.setCanDash(true);
        }
        else
        {
            // switches player to falling state
            player.SwitchState(player.FallingState);
        }
    }


    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        
    }

    // no movement occurs during idle state, so physics don't need updating
    public override void UpdatePhysics(PlayerStateManager player)
    {

    }
}


