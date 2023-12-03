using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsManager : MonoBehaviour
{
    // game objects are assigned in the inspector
    [SerializeField] private GameObject TimerToggleObject;
    [SerializeField] private GameObject AerialAidSliderObject;
    [SerializeField] private GameObject RebindJumpObject;
    [SerializeField] private GameObject RebindDashObject;
    [SerializeField] private GameObject RebindClimbObject;
    [SerializeField] private GameObject ActivateWASDObject;
    [SerializeField] private GameObject ActivateArrowsObject;
    [SerializeField] private GameObject ResetOptionsObject;

    [SerializeField] private GameObject NewKeyBackgroundObject;
    [SerializeField] private GameObject NewKeyTextObject;

    // attributes for each UI element
    private Toggle timerToggle;
    private Slider aerialAidSlider;
    private Button RebindJump;
    private Button RebindDash;
    private Button RebindClimb;
    private Button ActivateWASD;
    private Button ActivateArrows;
    private Button ResetOptions;

    void Start()
    {
        // assign the components
        timerToggle = TimerToggleObject.GetComponent<Toggle>();
        aerialAidSlider = AerialAidSliderObject.GetComponent<Slider>();
        RebindJump = RebindJumpObject.GetComponent<Button>();
        RebindDash = RebindDashObject.GetComponent<Button>();
        RebindClimb = RebindClimbObject.GetComponent<Button>();
        ActivateWASD = ActivateWASDObject.GetComponent<Button>();
        ActivateArrows = ActivateArrowsObject.GetComponent<Button>();
        ResetOptions = ResetOptionsObject.GetComponent<Button>();

        // Add listeners for state changes
        timerToggle.onValueChanged.AddListener(ToggleChanged);
        aerialAidSlider.onValueChanged.AddListener(SliderChanged);
        RebindJump.onClick.AddListener(RebindJumpPressed);
        RebindDash.onClick.AddListener(RebindDashPressed);
        RebindClimb.onClick.AddListener(RebindClimbPressed);
        ActivateWASD.onClick.AddListener(ActivateWASDPressed);
        ActivateArrows.onClick.AddListener(ActivateArrowsPressed);
        ResetOptions.onClick.AddListener(ResetOptionsPressed);

    }

    private void ToggleChanged(bool value)
    {
        SettingsTracker.timerActive = value;
    }
    private void SliderChanged(float value)
    {
        // slider has a range of 1-4 so dividing by 4 means 0.25-1.00
        SettingsTracker.AerialAidMultiplier = value / 4;
    }
    private void RebindJumpPressed()
    {
        StartCoroutine(Rebind("Jump"));
    }
    private void RebindDashPressed()
    {
        StartCoroutine(Rebind("Dash"));
    }
    private void RebindClimbPressed()
    {
        StartCoroutine(Rebind("Climb"));
    }
    private void ActivateWASDPressed()
    {
        SettingsTracker.axisKeys = true;
    }
    private void ActivateArrowsPressed()
    {
        SettingsTracker.axisKeys = false;
    }
    private void ResetOptionsPressed()
    {
        // sets attributes to original values
        SettingsTracker.jumpKey = KeyCode.Space;
        SettingsTracker.dashKey = KeyCode.K;
        SettingsTracker.climbKey = KeyCode.L;
        SettingsTracker.axisKeys = true;
        SettingsTracker.AerialAidMultiplier = 1f;
        SettingsTracker.timerActive = false;

        timerToggle.isOn = false;
        aerialAidSlider.value = 4;
    }


    private IEnumerator Rebind(string inputType)
    {
        NewKeyBackgroundObject.SetActive(true);
        NewKeyTextObject.SetActive(true);

        // Wait until no keys are pressed
        while (Input.anyKey)
        {
            yield return null;
        }

        // Wait for the next key press
        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        // Find the first key that is pressed
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                // check which key is being updated
                if (inputType == "Jump")
                {
                    SettingsTracker.jumpKey = keyCode;
                    Debug.Log("Jump Key rebound to: " + SettingsTracker.jumpKey);
                }
                if (inputType == "Dash")
                {
                    SettingsTracker.dashKey = keyCode;
                    Debug.Log("Dash Key rebound to: " + SettingsTracker.dashKey);
                }
                if (inputType == "Climb")
                {
                    SettingsTracker.climbKey = keyCode;
                    Debug.Log("Climb Key rebound to: " + SettingsTracker.climbKey);
                }

                NewKeyBackgroundObject.SetActive(false);
                NewKeyTextObject.SetActive(false);
                yield break;
            }
        }
    }

}
