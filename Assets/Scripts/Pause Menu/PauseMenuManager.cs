using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    // parent objects of UI elements
    [SerializeField] GameObject paused;
    [SerializeField] GameObject records;
    [SerializeField] GameObject options;
    [SerializeField] GameObject loading;
    [SerializeField] GameObject textbox;
    [SerializeField] GameObject counter;

    private bool isPaused;

    // audio source for click sfx
    [SerializeField] AudioSource src;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(!isPaused)
            {
                isPaused = true;
                NewMenuScreen("paused");
            }
            else
            {
                isPaused = false;
                NewMenuScreen("resume");
            }

        }
    }


    public void NewMenuScreen(string menu)
    {
        // disable all UI elements
        paused.SetActive(false);
        textbox.SetActive(false);
        counter.SetActive(false);
                //records.SetActive(false);
                //options.SetActive(false);

        // play sound effect
        src.Play();

        switch (menu)
        {
            case "resume":
                // don't enable any other menu
                Time.timeScale = 1f;
                break;
            case "paused":
                // enable paused UI
                paused.SetActive(true);
                Time.timeScale = 0f;
                break;
            case "records":
                // enable records UI
                                        //records.SetActive(true);
                break;
            case "options":
                // enable options UI
                                    //options.SetActive(true);
                break;
            case "exit":
                // enable loading UI
                                    //loading.SetActive(true);
                // return to menu
                SceneManager.LoadScene("Menu");
                break;
            default:
                Debug.Log("Switch Error");
                break;
        }
    }
}