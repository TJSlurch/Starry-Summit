using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Idle State");

        // sets velocity to 0 as soon as no input is detected
        player.setVelocity(new Vector2(0, player.getY()));

        //refreshes dash ability
        player.setCanDash(true);
    }

    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        // detects if a jump request is active
        if (player.getJumpRequest())
        {
            // switches to jump state
            player.SwitchState(player.JumpState);
            player.setJumpRequest(false);
        }

        // detects if vertical velocity is negative (downwards)
        if (player.getY() < -0.01)
        {
            // switches player to falling state
            player.SwitchState(player.FallingState);
        }

        // detects if horizontal input isn't zero
        if (Mathf.Abs(player.getInput()) > Mathf.Epsilon)
        {
            // switches player to run state
            player.SwitchState(player.RunState);
        }







        if(Mathf.Abs(Input.GetAxis("dashY")) > Mathf.Epsilon || Mathf.Abs(Input.GetAxis("dashX")) > Mathf.Epsilon)
        {
            player.SwitchState(player.DashState);
        }







    }

    // no movement occurs during idle state, so physics don't need updating
    public override void UpdatePhysics(PlayerStateManager player)
    {

    }
}