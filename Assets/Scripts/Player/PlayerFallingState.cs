using UnityEngine;

public class PlayerFallingState : PlayerBaseState
{
    private float fallMultiplier = 5f;
    private float weightlessGravity = 1f;

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Falling State");
    }

    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        // detects if vertical velocity is zero (no vertical movement)
        if (Mathf.Abs(player.rb.velocity.y) < 0.01)
        {
            // switches to idle state
            player.SwitchState(player.IdleState);
        }

        // detects if horizontal input isn't zero
        if (Mathf.Abs(player.getInput()) > Mathf.Epsilon && Mathf.Abs(player.rb.velocity.y) < 0.01)
        {
            // switches player to run state
            player.SwitchState(player.RunState);
        }
    }

    // what happens every frame whilst this state is active
    public override void UpdatePhysics(PlayerStateManager player)
    {
        // at the peak of the player's jump, they experience reduced gravity
        if (player.rb.velocity.y > -1)
        {
            player.rb.gravityScale = weightlessGravity;
        }
        // gravity is then increased to a maximum as the jump ends
        else
        {
            player.rb.gravityScale = fallMultiplier;
        }
      
        // detects horizontal input and uses it to change player velocity
        Vector2 movement = new Vector2(player.getInput() * player.speed, player.rb.velocity.y);
        player.rb.velocity = movement;
    }
}
