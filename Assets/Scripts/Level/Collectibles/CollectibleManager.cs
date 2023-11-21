using System.Collections;
using UnityEngine;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    private bool[] collectibleArray = new bool[10];
    private int collectibleTotal = 0;

    // UI/Audio elements
    [SerializeField] private AudioSource AudioSRC;
    [SerializeField] private GameObject counterNumberUI;
    [SerializeField] private GameObject counterUI;
    private TextMeshProUGUI counterNumber;
    private GameObject counter;

    private void Start()
    {
        // assigns the game objects to their variable
        counter = counterUI;
        counterNumber = counterNumberUI.GetComponent<TextMeshProUGUI>();

        // sets each value of the array to false
        for(int i = 0; i < collectibleArray.Length; i++)
        {
            collectibleArray[i] = false;
        }
    }

    // the method ran when a new collectible is collected
    public IEnumerator newCollectible(int num)
    {
        // increase counter, update array and play sfx
        collectibleTotal++;
        collectibleArray[num] = true;
        AudioSRC.Play();

        // show UI for 3 seconds total before hiding it again
        counter.SetActive(true);
        // pause momentarily before updating the UI to show the increase
        yield return new WaitForSeconds(0.5f);
        counterNumber.text = collectibleTotal.ToString();
        yield return new WaitForSeconds(2.5f);
        counter.SetActive(false);
    }
}



