using System.Collections;
using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    private float dashSpeed = 3f;
    private float dashTime = 3f;
    public MonoBehaviour monoBehaviour;

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Dash State");
        player.setVelocity(new Vector2(Input.GetAxis("dashX") * dashSpeed, Input.GetAxis("dashY") * dashSpeed));
        player.setGravity(0f);

        monoBehaviour.StartCoroutine(endDash());

        Debug.Log("111111111");
        player.setGravity(2f);

        player.SwitchState(player.FallingState);
    }

    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        
    }

    // no movement occurs during idle state, so physics don't need updating
    public override void UpdatePhysics(PlayerStateManager player)
    {

    }

    public IEnumerator endDash()
    {
        yield return new WaitForSeconds(dashTime);
        yield return null;
    }
}
