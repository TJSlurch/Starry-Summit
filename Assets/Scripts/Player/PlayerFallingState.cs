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
        // detects if vertical velocity is zero (no vertical movement)
        if (Mathf.Abs(player.getY()) < 0.01)
        {
            // switches to idle state
            player.SwitchState(player.IdleState);
        }

        // detects if horizontal input isn't zero
        if (Mathf.Abs(player.getInput()) > Mathf.Epsilon && Mathf.Abs(player.getY()) < 0.01)
        {
            // switches player to run state
            player.SwitchState(player.RunState);
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
