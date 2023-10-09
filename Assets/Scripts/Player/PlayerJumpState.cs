using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Jump State");
        player.rb.velocity = new Vector2(player.getX(), player.jumpForce);
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
    }

    // what happens every frame whilst this state is active
    public override void UpdatePhysics(PlayerStateManager player)
    {
        // detects horizontal input and uses it to change player velocity
        Vector2 movement = new Vector2(player.getInput() * player.speed, player.getY());
        player.rb.velocity = movement;
    }
}
