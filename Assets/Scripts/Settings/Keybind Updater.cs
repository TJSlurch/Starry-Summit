using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeybindUpdater : MonoBehaviour
{
    // game objects are assigned in the inspector
    [SerializeField] private GameObject RunControlObject;
    [SerializeField] private GameObject ClimbControlObject;
    [SerializeField] private GameObject JumpControlObject;
    [SerializeField] private GameObject WallHoldControlObject;
    [SerializeField] private GameObject DashControlObject;
    [SerializeField] private GameObject TextboxRunObject;
    [SerializeField] private GameObject TextboxJumpObject;
    [SerializeField] private GameObject TextboxClimbObject;
    [SerializeField] private GameObject TextboxDashObject;

    TextMeshProUGUI RunControlText;
    TextMeshProUGUI ClimbControlText;
    TextMeshProUGUI JumpControlText;
    TextMeshProUGUI WallHoldControlText;
    TextMeshProUGUI DashControlText;
    TextBoxColliderManager TextboxRunText;
    TextBoxColliderManager TextboxJumpText;
    TextBoxColliderManager TextboxClimbText;
    TextBoxColliderManager TextboxDashText;

    // true = main menu, false = gameplay menu
    [SerializeField] private bool onMainMenu;

    void Start()
    {
        RunControlText = RunControlObject.GetComponent<TextMeshProUGUI>();
        ClimbControlText = ClimbControlObject.GetComponent<TextMeshProUGUI>();
        JumpControlText = JumpControlObject.GetComponent<TextMeshProUGUI>();
        WallHoldControlText = WallHoldControlObject.GetComponent<TextMeshProUGUI>();
        DashControlText = DashControlObject.GetComponent<TextMeshProUGUI>();
        TextboxRunText = TextboxRunObject.GetComponent<TextBoxColliderManager>();
        TextboxJumpText = TextboxJumpObject.GetComponent<TextBoxColliderManager>();
        TextboxClimbText = TextboxClimbObject.GetComponent<TextBoxColliderManager>();
        TextboxDashText = TextboxDashObject.GetComponent<TextBoxColliderManager>();

        if (SettingsTracker.axisKeys == true && !onMainMenu)
            TextboxRunText.sentence = "Press A to move left                        Press D to move right";
        if(SettingsTracker.axisKeys == false && !onMainMenu)
            TextboxRunText.sentence = "Press Left Arrow for left                     Press Right Arrow for right";
               
    }

    // Update is called once per frame
    void Update()
    {
        if(SettingsTracker.axisKeys == true)
        {
            RunControlText.text = "A / D";
            ClimbControlText.text = "W / S";
            if (!onMainMenu)
            {
                TextboxRunText.sentence = "Press A to move left                        Press D to move right";
                TextboxClimbText.sentence = "Hold " + SettingsTracker.climbKey.ToString() + " to grab onto a wall!              then press W or S to climb,";
            }
        }
        else
        {
            RunControlText.text = "Left / Right";
            ClimbControlText.text = "Up / Down";
            if (!onMainMenu)
            {
                TextboxRunText.sentence = "Press Left Arrow for left                     Press Right Arrow for right";
                TextboxClimbText.sentence = "Hold " + SettingsTracker.climbKey.ToString() + " to grab onto a wall!              then press up arrow or down arrow to climb,";
            }
        }

        JumpControlText.text = SettingsTracker.jumpKey.ToString();
        WallHoldControlText.text = SettingsTracker.climbKey.ToString();
        DashControlText.text = SettingsTracker.dashKey.ToString();
        if (!onMainMenu)
        {
            TextboxJumpText.sentence = "Press " + SettingsTracker.jumpKey.ToString() + " to jump";
            TextboxDashText.sentence = "Press " + SettingsTracker.dashKey.ToString() + " whilst moving to dash!";
        }
    }
}
