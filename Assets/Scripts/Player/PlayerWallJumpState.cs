using UnityEngine;
using System.Collections;

public class PlayerWallJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Wall Jump State");
        player.setGravity(2f);

        // if wall is on left, launch to the right (positive)
        if (player.getTouchingLeft())
        {
            player.setVelocity(new Vector2(1f, 0.8f) * player.getJumpForce());
        }
        // if wall is on right, launch to the left (negative)
        else
        {
            player.setVelocity(new Vector2(-1f, 0.8f) * player.getJumpForce());
        }

        // starts the process of ending the wall jump
        player.StartCoroutine(endWallJump(player));
    }

    // coroutine which resets the player's movement
    public IEnumerator endWallJump(PlayerStateManager player)
    {
        // waits for the length of the wall jump
        yield return new WaitForSeconds(0.3f);
        player.SwitchState(player.FallingState);
    }


    // coroutine must be stopped before switching early
    public override void UpdateState(PlayerStateManager player)
    {
        // initiates a dash mid wall jump
        if ((Mathf.Abs(Input.GetAxis("dashY")) > Mathf.Epsilon || Mathf.Abs(Input.GetAxis("dashX")) > Mathf.Epsilon) & player.getCanDash())
        {
            player.StopCoroutine(endWallJump(player));
            player.SwitchState(player.DashState);
        }
        // initiates wall grab mid wall jump
        if (player.getTouchingLeft() && player.getX() < 0 && Input.GetKey(KeyCode.LeftShift) || (player.getTouchingRight() && player.getX() > 0 && Input.GetKey(KeyCode.LeftShift)))
        {
            player.StopCoroutine(endWallJump(player));
            player.SwitchState(player.WallGrabState);
        }
    }
    public override void UpdatePhysics(PlayerStateManager player)
    {
        player.setVelocity(new Vector2(player.getX() * 0.92f, player.getY()));
    }
}
