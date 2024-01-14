using System.Collections;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    // What happens when a death is triggered
    public override void EnterState(PlayerStateManager player)
    {
        player.triggerAnimator("DeathTrigger");
        player.playDeath();
        player.setVelocity(new Vector2(0, 0));
        player.setGravity(0f);
        Time.timeScale = 1f;

        // increase death stat
        StatsTracker.currentDeaths++;
        StatsTracker.totalDeaths++;

        // starts the respawn sequence
        player.StartCoroutine(respawn(player));
    }

    // coroutine which switches back to gameplay again
    public IEnumerator respawn(PlayerStateManager player)
    {
        // waits for the animation to play, then moves player
        yield return new WaitForSeconds(1.25f);
        player.ResetToCheckpoint();

        // waits briefly before enabling gameplay again
        yield return new WaitForSeconds(0.1f);
        player.setCanDash(true);
        player.setGravity(8f);
        player.SwitchState(player.IdleState);
    }




    public override void UpdateState(PlayerStateManager player)
    {
    
    }

    public override void UpdatePhysics(PlayerStateManager player)
    {
       
    }
}
