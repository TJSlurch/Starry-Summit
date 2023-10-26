using UnityEngine;

public class PlayerWallJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Wall Jump State");
    }
    public override void UpdateState(PlayerStateManager player)
    {

    }
    public override void UpdatePhysics(PlayerStateManager player)
    {

    }
}
