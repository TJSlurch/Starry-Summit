using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    // parent objects of UI elements
    [SerializeField] GameObject paused;
    [SerializeField] GameObject records;
    [SerializeField] GameObject options;
    [SerializeField] GameObject loading;
    [SerializeField] GameObject textbox;
    [SerializeField] GameObject counter;
    [SerializeField] GameObject background;
    [SerializeField] GameObject hamburger;

    // audio source for click sfx
    [SerializeField] AudioSource src;

    // the variable which tracks if the pause menu is active
    private bool isPaused;

    void Start()
    {
        // setup listener
        Button btn = hamburger.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        changePaused();
    }

    private void Update()
    {
        // pressing escape pauses/unpauses the game
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            changePaused();
        }
    }


    private void changePaused()
    {
        // if not paused
        if (!isPaused)
        {
            isPaused = true;
            background.SetActive(true);
            textbox.SetActive(false);
            counter.SetActive(false);
            hamburger.SetActive(false);
            // pauses
            Time.timeScale = 0f;
            NewMenuScreen("paused");
        }
        // if paused
        else
        {
            isPaused = false;
            background.SetActive(false);
            paused.SetActive(false);
            records.SetActive(false);
            options.SetActive(false);
            hamburger.SetActive(true);
            // unpauses
            Time.timeScale = 1f;
        }
    }


    public void NewMenuScreen(string menu)
    {
        // disable all UI elements
        paused.SetActive(false);
        records.SetActive(false);
        options.SetActive(false);

        // play sound effect
        src.Play();

        switch (menu)
        {
            case "paused":
                // enable paused UI
                paused.SetActive(true);
                break;
            case "resume":
                // switch paused state
                changePaused();
                break;
            case "records":
                // enable records UI
                records.SetActive(true);
                break;
            case "options":
                // enable options UI
                options.SetActive(true);
                break;
            case "exit":
                // enable loading UI
                loading.SetActive(true);
                Time.timeScale = 1f;
                // return to menu
                SceneManager.LoadScene("Menu");
                break;
            default:
                Debug.Log("Switch Error");
                break;
        }
    }
}