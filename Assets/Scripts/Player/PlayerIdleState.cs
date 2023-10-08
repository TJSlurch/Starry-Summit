using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Idle State");
    }

    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            player.rb.velocity = new Vector2(player.rb.velocity.x, player.jumpForce);
            player.SwitchState(player.JumpState);
        }

        if(player.rb.velocity.y < 0)
        {
            player.SwitchState(player.FallingState);
        }

        if (Mathf.Abs(player.horizontalInput) > Mathf.Epsilon)
        {
            player.SwitchState(player.RunState);
        }
    }

    public override void UpdatePhysics(PlayerStateManager player)
    {

    }
}
