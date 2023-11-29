using System;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject speedrunTimerObject;
    private TextMeshProUGUI speedrunTimerText;

    void Start()
    {
        speedrunTimerText = speedrunTimerObject.GetComponent<TextMeshProUGUI>();

        // no where else to go lmaoaaaaaaaaaaaaaaaaaaaaaaaaaa
        StatsTracker.currentDeaths = 0;
        StatsTracker.currentCollectibles = 0;
        StatsTracker.currentTime = 0f;
        StatsTracker.currentProgress = 0;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        StatsTracker.currentTime += Time.deltaTime;
        StatsTracker.totalTime += Time.deltaTime;

        speedrunTimerText.text = TimeSpan.FromSeconds(StatsTracker.currentTime).ToString("mm':'ss':'ff");
    }
}
