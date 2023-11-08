using UnityEngine;
using System.Collections;

public class PlayerWallJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Wall Jump State");
        player.triggerAnimator("JumpTrigger");
        player.playJump();

        // increases gravity since it is zero in wall climb
        player.setGravity(8f);
        player.setJumpRequest(false);

        // if wall is on left, launch up/right
        if (player.getTouchingLeft())
        {
            player.setVelocity(new Vector2(0.8f, 0.8f) * player.getJumpForce());
            player.StartCoroutine(endWallJump(player));
        }
        // if wall is on right, launch up/left
        else if (player.getTouchingRight())
        {
            player.setVelocity(new Vector2(-0.8f, 0.8f) * player.getJumpForce());
            player.StartCoroutine(endWallJump(player));
        }
        // if at the end of the wall, jump vertically only
        else
        {
            player.setVelocity(new Vector2(0f, 1.2f) * player.getJumpForce());
            player.StartCoroutine(endTopWallJump(player));
        }
    }

    // coroutine which resets the player's movement
    public IEnumerator endWallJump(PlayerStateManager player)
    {
        // waits for the length of the wall jump
        yield return new WaitForSeconds(0.3f);
        player.SwitchState(player.FallingState);
    }
    // coroutine which resets the player's movement if at the top of a wall
    public IEnumerator endTopWallJump(PlayerStateManager player)
    {
        // waits for the length of the wall jump
        yield return new WaitForSeconds(0.1f);
        player.SwitchState(player.FallingState);
    }


    // coroutine must be stopped before switching early
    public override void UpdateState(PlayerStateManager player)
    {
        // initiates a dash mid wall jump
        if (player.getCanDash() && (Input.GetAxis("Dash") > 0))
        {
            player.StopCoroutine(endWallJump(player));
            player.SwitchState(player.DashState);
        }
        // initiates wall grab mid wall jump
        if (player.getTouchingLeft() && player.getX() < 0 && Input.GetAxis("Wall Hold") > 0 || (player.getTouchingRight() && player.getX() > 0 && Input.GetAxis("Wall Hold") > 0))
        {
            player.StopCoroutine(endWallJump(player));
            player.SwitchState(player.WallGrabState);
        }
    }
    public override void UpdatePhysics(PlayerStateManager player)
    {
        // adds horizontal drag to the jump
        player.setVelocity(new Vector2(player.getX() * 0.98f, player.getY()));

        // flips sprite depending on direction
        if (player.getX() < 0)
        {
            player.setSpriteDirection(true);
        }
        else
        {
            player.setSpriteDirection(false);
        }
    }
}
