using UnityEngine;

public class PlayerRunState : PlayerBaseState
{

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Run State");
        //refreshes dash ability
        player.setCanDash(true);
    }

    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        // detects for no horizontal input
        if (Mathf.Abs(player.getInput()) < Mathf.Epsilon)
        {
            // switches to idle state
            player.SwitchState(player.IdleState);
        }

        // detects if vertical velocity is negative (downwards)
        if (player.getY() < -0.01)
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



       

        if (Mathf.Abs(Input.GetAxis("dashY")) > Mathf.Epsilon || Mathf.Abs(Input.GetAxis("dashX")) > Mathf.Epsilon)
        {
            player.SwitchState(player.DashState);
        }





    }

    // what happens every frame whilst this state is active
    public override void UpdatePhysics(PlayerStateManager player)
    {
        // detects horizontal input and uses it to change player velocity
        player.setVelocity(new Vector2(player.getInput() * player.getSpeed(), player.getY()));
    }
}





