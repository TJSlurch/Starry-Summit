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
        // detects space bar being pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // switches to jump state
            player.SwitchState(player.JumpState);
        }

        // detects if vertical velocity is negative (downwards)
        if(player.getY() < -0.01)
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
    }

    // no movement occurs during idle state so physics don't need updating
    public override void UpdatePhysics(PlayerStateManager player)
    {

    }
}