using System;
using UnityEngine;
using TMPro;

public class RecordsManager : MonoBehaviour
{
    // declae the UI objects and their text attributes
    [SerializeField] GameObject CurrentDeathsObject;
    [SerializeField] GameObject CurrentCollectiblesObject;
    [SerializeField] GameObject CurrentTimeObject;
    [SerializeField] GameObject CurrentProgressObject;
    [SerializeField] GameObject TotalDeathsObject;
    [SerializeField] GameObject TotalCollectiblesObject;
    [SerializeField] GameObject TotalTimeObject;
    private TextMeshProUGUI currentDeathsText;
    private TextMeshProUGUI currentCollectiblesText;
    private TextMeshProUGUI currentTimeText;
    private TextMeshProUGUI currentProgressText;
    private TextMeshProUGUI totalDeathsText;
    private TextMeshProUGUI totalCollectiblesText;
    private TextMeshProUGUI totalTimeText;

    private void Start()
    {
        // assign the text attributes to the actual text components
        currentDeathsText = CurrentDeathsObject.GetComponent<TextMeshProUGUI>();
        currentCollectiblesText = CurrentCollectiblesObject.GetComponent<TextMeshProUGUI>();
        currentTimeText = CurrentTimeObject.GetComponent<TextMeshProUGUI>();
        currentProgressText = CurrentProgressObject.GetComponent<TextMeshProUGUI>();
        totalDeathsText = TotalDeathsObject.GetComponent<TextMeshProUGUI>();
        totalCollectiblesText = TotalCollectiblesObject.GetComponent<TextMeshProUGUI>();
        totalTimeText = TotalTimeObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        currentDeathsText.text = "Current Deaths: " + StatsTracker.currentDeaths.ToString();
        currentCollectiblesText.text = "Current Collectibles: " + StatsTracker.currentCollectibles.ToString();
        currentTimeText.text = "Current Time: " + TimeSpan.FromSeconds(StatsTracker.currentTime).ToString("hh':'mm':'ss");
        currentProgressText.text = "Current Progress: " + StatsTracker.currentProgress.ToString() + "%";
        totalDeathsText.text = "Total Deaths: " + StatsTracker.totalDeaths.ToString();
        totalCollectiblesText.text = "Total Collectibles: " + StatsTracker.totalCollectibles.ToString();
        totalTimeText.text = "Total Time: " + TimeSpan.FromSeconds(StatsTracker.totalTime).ToString("hh':'mm':'ss");
    }
}
