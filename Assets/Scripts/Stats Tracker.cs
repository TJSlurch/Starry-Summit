using UnityEngine;

public class StatsTracker : MonoBehaviour
{
    // attribrutes which can be accessed from either scene

    // total of each stat
    public static int totalDeaths = 0;
    public static int totalCollectibles = 0;
    public static float totalTime = 0;

    // each stat for the current playthrough
    public static int currentDeaths = 0;
    public static int currentCollectibles = 0;
    public static float currentTime = 0;
    public static float currentProgress = 0;

    // the record for each stat
    public static int fewestDeaths;
    public static int mostCollectibles;
    public static float fastestRun;

    // the record for the difficult stats
    public static float fastestDeathless;
    public static float fastestAllCollectibles;
    public static float fastestPerfect;
}
