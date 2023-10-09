using UnityEngine;

public class PlayerRunState : PlayerBaseState
{

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Run State");
    }

    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        // detects if horizontal input is zero
        if (Mathf.Abs(player.rb.velocity.x) < Mathf.Epsilon)
        {
            // switches to idle state
            player.SwitchState(player.IdleState);
        }

        // detects if vertical velocity is negative (downwards)
        if (player.rb.velocity.y < -0.01)
        {
            // switches player to falling state
            player.SwitchState(player.FallingState);
        }

        // detects if a jump request is active
        if (player.jumpRequest)
        {
            // switches to jump state
            player.SwitchState(player.JumpState);
            player.jumpRequest = false;
        }
    }

    // what happens every frame whilst this state is active
    public override void UpdatePhysics(PlayerStateManager player)
    {
        // detects horizontal input and uses it to change player velocity
        Vector2 movement = new Vector2(player.getInput() * player.speed, player.rb.velocity.y);
        player.rb.velocity = movement;
    }
}





