using UnityEngine;

public class PlayerFallingState : PlayerBaseState
{

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Falling State");
    }

    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        if (player.rb.velocity.y == 0)
        {
            player.SwitchState(player.IdleState);
        }
    }

    public override void UpdatePhysics(PlayerStateManager player)
    {
        Vector2 movement = new Vector2(player.horizontalInput * player.speed, player.rb.velocity.y);
        player.rb.velocity = movement;
    }
}
