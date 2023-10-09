using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private float lowJumpMultiplier = 3f;
    private float regularGravity = 2f;
    private float weightlessGravity = 1f;

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Jump State");
        player.rb.velocity = new Vector2(player.rb.velocity.x, player.jumpForce);
    }

    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        // detects if vertical velocity is negative (downwards)
        if (player.rb.velocity.y < -0.1)
        {
            // switches player to falling state
            player.SwitchState(player.FallingState);
        }
    }

    // what happens every frame whilst this state is active
    public override void UpdatePhysics(PlayerStateManager player)
    {
        // at the peak of the player's jump, they experience reduced gravity
        if (player.rb.velocity.y < 1)
        {
            player.rb.gravityScale = weightlessGravity;
        }
        // if space is held, gravity remains constant for a normal jump
        else if (Input.GetKey(KeyCode.Space))
        {
            player.rb.gravityScale = regularGravity;
        }
        // if space is released, gravity is increased for a shorter jump
        else
        {
            player.rb.gravityScale = lowJumpMultiplier;
        }

        // detects horizontal input and uses it to change player velocity
        Vector2 movement = new Vector2(player.getInput() * player.speed, player.rb.velocity.y);
        player.rb.velocity = movement;
    }
}
