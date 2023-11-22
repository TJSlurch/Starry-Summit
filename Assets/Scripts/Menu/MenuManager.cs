using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // parent objects of UI elements
    [SerializeField] GameObject title;
    [SerializeField] GameObject records;
    [SerializeField] GameObject options;
    [SerializeField] GameObject loading;

    // audio source for click sfx
    [SerializeField] AudioSource src;

    public void NewMenuScreen(string menu)
    {
        // disable all UI elements
        title.SetActive(false);
        records.SetActive(false);
        options.SetActive(false);

        // play sound effect
        src.Play();

        switch (menu)
        {
            case "title":
                // enable title UI
                title.SetActive(true);
                break;
            case "records":
                // enable records UI
                records.SetActive(true);
                break;
            case "options":
                // enable options UI
                options.SetActive(true);
                break;
            case "start":
                // enable loading UI
                loading.SetActive(true);
                // start gameplay
                SceneManager.LoadScene("Gameplay");
           
                break;
            default:
                Debug.Log("Switch Error");
                break;
        }
    }
}
