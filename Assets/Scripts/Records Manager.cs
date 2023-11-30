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

    [SerializeField] GameObject FewestDeathsObject;
    [SerializeField] GameObject MostCollectiblesObject;
    [SerializeField] GameObject FastestRunObject;

    [SerializeField] GameObject FastestDeathlessObject;
    [SerializeField] GameObject FastestAllCollectiblesObject;
    [SerializeField] GameObject FastestPerfectObject;

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

        // UNFINSUIHWDEDDD
        FewestDeathsText = TotalDeathsObject.GetComponent<TextMeshProUGUI>();
        MostCollectiblesText = TotalCollectiblesObject.GetComponent<TextMeshProUGUI>();
        FastestRunText = TotalTimeObject.GetComponent<TextMeshProUGUI>();
        FastestDeathlessText = TotalDeathsObject.GetComponent<TextMeshProUGUI>();
        FastestAllCollectiblesText = TotalCollectiblesObject.GetComponent<TextMeshProUGUI>();
        FastestPerfectText = TotalTimeObject.GetComponent<TextMeshProUGUI>();
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
