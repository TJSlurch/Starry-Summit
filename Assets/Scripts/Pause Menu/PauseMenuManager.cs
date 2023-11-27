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

    private bool isPaused;

    // audio source for click sfx
    [SerializeField] AudioSource src;

    void Start()
    {
        // setup listener
        Button btn = hamburger.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (!isPaused)
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
        records.SetActive(false);
        options.SetActive(false);

        // play sound effect
        src.Play();

        switch (menu)
        {
            case "resume":
                // don't enable any other menu
                Time.timeScale = 1f;
                isPaused = false;
                background.SetActive(false);
                hamburger.SetActive(true);
                break;
            case "paused":
                // enable paused UI
                paused.SetActive(true);
                background.SetActive(true);
                textbox.SetActive(false);
                counter.SetActive(false);
                hamburger.SetActive(false);
                Time.timeScale = 0f;
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