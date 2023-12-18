using System;
using UnityEngine;
using TMPro;

public class RecordsManager : MonoBehaviour
{
    // find the UI objects through the inspector
    [SerializeField] GameObject CurrentDeathsObject;
    [SerializeField] GameObject CurrentCollectiblesObject;
    [SerializeField] GameObject CurrentTimeObject;
    [SerializeField] GameObject CurrentProgressObject;
    [SerializeField] GameObject TotalDeathsObject;
    [SerializeField] GameObject TotalCollectiblesObject;
    [SerializeField] GameObject TotalTimeObject;
    [SerializeField] GameObject FewestDeathsObject;
    [SerializeField] GameObject MostCollectiblesObject;
    [SerializeField] GameObject FastestRunObject;
    [SerializeField] GameObject FastestDeathlessObject;
    [SerializeField] GameObject FastestAllCollectiblesObject;
    [SerializeField] GameObject FastestPerfectObject;

    // declare text variables for each
    private TextMeshProUGUI currentDeathsText;
    private TextMeshProUGUI currentCollectiblesText;
    private TextMeshProUGUI currentTimeText;
    private TextMeshProUGUI currentProgressText;
    private TextMeshProUGUI totalDeathsText;
    private TextMeshProUGUI totalCollectiblesText;
    private TextMeshProUGUI totalTimeText;
    private TextMeshProUGUI FewestDeathsText;
    private TextMeshProUGUI MostCollectiblesText;
    private TextMeshProUGUI FastestRunText;
    private TextMeshProUGUI FastestDeathlessText;
    private TextMeshProUGUI FastestAllCollectiblesText;
    private TextMeshProUGUI FastestPerfectText;


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
        FewestDeathsText = FewestDeathsObject.GetComponent<TextMeshProUGUI>();
        MostCollectiblesText = MostCollectiblesObject.GetComponent<TextMeshProUGUI>();
        FastestRunText = FastestRunObject.GetComponent<TextMeshProUGUI>();
        FastestDeathlessText = FastestDeathlessObject.GetComponent<TextMeshProUGUI>();
        FastestAllCollectiblesText = FastestAllCollectiblesObject.GetComponent<TextMeshProUGUI>();
        FastestPerfectText = FastestPerfectObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // update their text
        currentDeathsText.text = "Deaths: " + StatsTracker.currentDeaths.ToString();
        currentCollectiblesText.text = "Stars: " + StatsTracker.currentCollectibles.ToString() + " / 10 ";
        currentTimeText.text = "Time: " + TimeSpan.FromSeconds(StatsTracker.currentTime).ToString("mm':'ss'.'ff");
        currentProgressText.text = "Progress: " + StatsTracker.currentProgress.ToString() + "%";
        totalDeathsText.text = "Deaths: " + StatsTracker.totalDeaths.ToString();
        totalCollectiblesText.text = "Stars: " + StatsTracker.totalCollectibles.ToString() + " / 10 ";
        totalTimeText.text = "Time: " + TimeSpan.FromSeconds(StatsTracker.totalTime).ToString("hh':'mm':'ss");
        if (StatsTracker.fewestDeaths != 1000)
            FewestDeathsText.text = "Fewest Deaths: " + StatsTracker.fewestDeaths.ToString();
        if (StatsTracker.mostCollectibles != -1)
            MostCollectiblesText.text = "Most Stars: " + StatsTracker.mostCollectibles.ToString() + " / 10 ";
        if(StatsTracker.fastestRun > 0)
            FastestRunText.text = "Completion: " + TimeSpan.FromSeconds(StatsTracker.fastestRun).ToString("mm':'ss'.'ff");
        if (StatsTracker.fastestDeathless > 0)
            FastestDeathlessText.text = "Deathless: " + TimeSpan.FromSeconds(StatsTracker.fastestDeathless).ToString("mm':'ss'.'ff");
        if (StatsTracker.fastestAllCollectibles > 0)
            FastestAllCollectiblesText.text = "All Stars: " + TimeSpan.FromSeconds(StatsTracker.fastestAllCollectibles).ToString("mm':'ss'.'ff");
        if (StatsTracker.fastestPerfect > 0)
            FastestPerfectText.text = "Perfect: " + TimeSpan.FromSeconds(StatsTracker.fastestPerfect).ToString("mm':'ss'.'ff");
    }
}
