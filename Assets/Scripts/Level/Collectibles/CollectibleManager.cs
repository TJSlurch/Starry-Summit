using System.Collections;
using UnityEngine;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    private static bool[] collectibleArray = new bool[20];

    // UI/Audio elements
    [SerializeField] private AudioSource AudioSRC;
    [SerializeField] private GameObject counterNumberUI;
    [SerializeField] private GameObject counterUI;
    private TextMeshProUGUI counterNumber;
    private GameObject counter;
    private int totalCollectibles;

    private void Start()
    {
        // assigns the game objects to their variable
        counter = counterUI;
        counterNumber = counterNumberUI.GetComponent<TextMeshProUGUI>();
    }

    // the method ran when a new collectible is collected
    public IEnumerator newCollectible(int num)
    {
        // increase counter, update array and play sfx
        StatsTracker.currentCollectibles++;

        collectibleArray[num] = true;
        AudioSRC.Play();

        totalCollectibles = 0;
        for(int i = 0; i < 10; i++)
        {
            if(collectibleArray[i] == true)
            {
                totalCollectibles++;
            }
        }
        StatsTracker.totalCollectibles = totalCollectibles;

        // show UI for 3 seconds total before hiding it again
        counter.SetActive(true);
        // pause momentarily before updating the UI to show the increase
        yield return new WaitForSeconds(0.5f);
        counterNumber.text = StatsTracker.currentCollectibles.ToString() + " / 10 ";
        yield return new WaitForSeconds(2.5f);
        counter.SetActive(false);
    }
}



