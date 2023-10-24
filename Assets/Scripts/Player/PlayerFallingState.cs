using UnityEngine;
using System.Collections;

public class PlayerFallingState : PlayerBaseState
{
    private float fallMultiplier = 5f;
    private float weightlessGravity = 1f;

    // what happens when this state is switched to
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering Falling State");
    }

    // what happens every frame whilst this state is active
    public override void UpdateState(PlayerStateManager player)
    {
        // detects if horizontal input isn't zero
        if (Mathf.Abs(player.getInput()) > Mathf.Epsilon && player.getTouchingDown())
        {
            // switches player to run state
            player.SwitchState(player.RunState);
            // waits briefly to prevent dash spam
            player.StartCoroutine(waitSeconds(0.25f, player));
            player.setCanDash(true);
        }
        // detects if player is touching the ground
        else if (player.getTouchingDown())
        {
            // switches to idle state
            player.SwitchState(player.IdleState);
            // waits briefly to prevent dash spam
            player.StartCoroutine(waitSeconds(0.25f, player));
            player.setCanDash(true);
        }

        // initiates a dash if arrow keys are pressed whilst a dash is possible
        if ((Mathf.Abs(Input.GetAxis("dashY")) > Mathf.Epsilon || Mathf.Abs(Input.GetAxis("dashX")) > Mathf.Epsilon) & player.getCanDash())
        {
            player.SwitchState(player.DashState);
        }
    }

    // what happens every frame whilst this state is active
    public override void UpdatePhysics(PlayerStateManager player)
    {
        // at the peak of the player's jump, they experience reduced gravity
        if (player.getY() > -1)
        {
            player.setGravity(weightlessGravity);
        }
        // gravity is then increased to a maximum as the jump ends
        else
        {
            player.setGravity(fallMultiplier);
        }
      
        // detects horizontal input and uses it to change player velocity
        player.setVelocity(new Vector2(player.getInput() * player.getSpeed(), player.getY()));
    }

    // Wait seconds coroutine which prevents dashing from being enabled immediately
    public IEnumerator waitSeconds(float time, PlayerStateManager player)
    {
        yield return new WaitForSeconds(0.25f);
    }
}
