using System.Collections;
using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    private float dashSpeed = 3f;
    private float dashTime = 0.2f;

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Dash State");
        player.setCanDash(false);
        //player.setVelocity(new Vector2(Input.GetAxis("dashX") * dashSpeed, Input.GetAxis("dashY") * dashSpeed));
        //player.setVelocity(new Vector2(Input.GetAxis("dashX") * player.SPEED, Input.GetAxis("dashY") * player.SPEED));
        player.addForce(new Vector2(Input.GetAxis("dashX") * player.SPEED, Input.GetAxis("dashY") * player.SPEED));
        player.setGravity(0f);
        //player.setLinearDrag(player.DRAG);

        //player.StartCoroutine(endDash(dashTime,player));
        player.StartCoroutine(endDash(player.TIME, player));
    }

    // coroutine which changes gravity back after the desired time
    public IEnumerator endDash(float time, PlayerStateManager player)
    {
        yield return new WaitForSeconds(time);
        player.setGravity(5f);
        //player.setLinearDrag(0f);

        if (Mathf.Abs(player.getY()) > 0.01)
        {
            // switches player to falling state
            player.SwitchState(player.FallingState);
        }
        // detects if horizontal input isn't zero
        else if (Mathf.Abs(player.getInput()) > Mathf.Epsilon)
        {
            // switches player to run state
            player.SwitchState(player.RunState);
        }
        else
        {
            // switches to idle state
            player.SwitchState(player.IdleState);
        }
    }



    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        
    }

    // no movement occurs during idle state, so physics don't need updating
    public override void UpdatePhysics(PlayerStateManager player)
    {

    }
}
