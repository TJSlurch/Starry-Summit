using UnityEngine;

public class PlayerWallClimbState : PlayerBaseState
{
    private int touchingWallMultiplier;

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Wall Climb State");
    }
    public override void UpdateState(PlayerStateManager player)
    {
        // when shift is released, a new state is entered
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            // choosing which state to enter
            if (Mathf.Abs(player.getInputX()) > Mathf.Epsilon && player.getTouchingDown())
            {
                // switches player to run state
                player.SwitchState(player.RunState);
            }
            else if (player.getTouchingDown())
            {
                // switches to idle state
                player.SwitchState(player.IdleState);
            }
            else
            {
                // switches player to falling state
                player.SwitchState(player.FallingState);
            }
        }

        // initiates a dash from wall climb
        if ((Mathf.Abs(Input.GetAxis("dashY")) > Mathf.Epsilon || Mathf.Abs(Input.GetAxis("dashX")) > Mathf.Epsilon) & player.getCanDash())
        {
            player.SwitchState(player.DashState);
        }

        // switches back to wall grab state if no vertical velocity is detected
        if (Mathf.Abs(player.getY()) < Mathf.Epsilon)
        {
            player.SwitchState(player.WallGrabState);
        }
    }
    public override void UpdatePhysics(PlayerStateManager player)
    {

        // TRY TO SORT THIS MESS OUT




        // moves up or down depending on if W or S are pressed
        player.setVelocity(new Vector2(0, player.getInputY() * player.getClimbSpeed() * touchingWallMultiplier));
        if(player.getTouchingLeft() || player.getTouchingRight())
        {
            touchingWallMultiplier = 1;
        }
        else
        {
            touchingWallMultiplier = 0;
        }






    }
}
