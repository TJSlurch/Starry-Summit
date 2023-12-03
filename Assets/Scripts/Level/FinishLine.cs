using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private int totalCollectibles = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checks if the deaths are a new record
        if (StatsTracker.currentDeaths < StatsTracker.fewestDeaths || StatsTracker.fewestDeaths == 0)
            StatsTracker.fewestDeaths = StatsTracker.currentDeaths;

        // checks if the collectibles are a new record
        if (StatsTracker.currentCollectibles > StatsTracker.mostCollectibles || StatsTracker.mostCollectibles == 0)
            StatsTracker.mostCollectibles = StatsTracker.currentCollectibles;

        // checks if the time is a new record
        if (StatsTracker.currentTime < StatsTracker.fastestRun || StatsTracker.fastestRun == 0)
            StatsTracker.fastestRun = StatsTracker.currentTime;


        // checks if it was deathless and a new record
        if ((StatsTracker.currentDeaths == 0) && (StatsTracker.currentTime < StatsTracker.fastestDeathless || StatsTracker.fastestDeathless == 0))
            StatsTracker.fastestDeathless = StatsTracker.currentTime;

        // checks if all collectibles were collected and a new record
        if ((StatsTracker.currentCollectibles == totalCollectibles) && (StatsTracker.currentTime < StatsTracker.fastestDeathless || StatsTracker.fastestDeathless == 0))
            StatsTracker.fastestDeathless = StatsTracker.currentTime;

        // checks if all collectibles were collected and deathless and a new record
        if ((StatsTracker.currentDeaths == 0) && (StatsTracker.currentDeaths == 0) && (StatsTracker.currentTime < StatsTracker.fastestDeathless || StatsTracker.fastestDeathless == 0))
            StatsTracker.fastestPerfect = StatsTracker.currentTime;

        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
