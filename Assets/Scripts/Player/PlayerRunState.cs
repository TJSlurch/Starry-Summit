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
       

        // this statement checks for a key being held down for multiple frames
        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            player.SwitchState(player.IdleState);
        }
    }
}





