using System.Collections;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    private bool[] collectibleArray = {false};
    private int collectibleTotal = 0;

    // the method ran when a new collectible is collected
    public IEnumerator newCollectible(int num)
    {
        collectibleTotal++;
        collectibleArray[num] = true;

        Debug.Log("collected collectible: " + num);
        Debug.Log("total collected: " + collectibleTotal);

        // show UI
        yield return new WaitForSeconds(2f);
        // Hide UI
    }

    public int getCollectibleTotal()
    {
        return collectibleTotal;
    }
}
