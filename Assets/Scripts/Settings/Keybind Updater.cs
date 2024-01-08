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
    [SerializeField] private GameObject TextboxHoldJumpObject;
    [SerializeField] private GameObject TextboxClimbObject;
    [SerializeField] private GameObject TextboxWallJumpObject;
    [SerializeField] private GameObject TextboxDashObject;

    TextMeshProUGUI RunControlText;
    TextMeshProUGUI ClimbControlText;
    TextMeshProUGUI JumpControlText;
    TextMeshProUGUI WallHoldControlText;
    TextMeshProUGUI DashControlText;
    TextBoxColliderManager TextboxRunText;
    TextBoxColliderManager TextboxJumpText;
    TextBoxColliderManager TextboxHoldJumpText;
    TextBoxColliderManager TextboxClimbText;
    TextBoxColliderManager TextboxWallJumpText;
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
        TextboxHoldJumpText = TextboxHoldJumpObject.GetComponent<TextBoxColliderManager>();
        TextboxClimbText = TextboxClimbObject.GetComponent<TextBoxColliderManager>();
        TextboxWallJumpText = TextboxWallJumpObject.GetComponent<TextBoxColliderManager>();
        TextboxDashText = TextboxDashObject.GetComponent<TextBoxColliderManager>();

        if (SettingsTracker.axisKeys == true && !onMainMenu)
            TextboxRunText.sentence = "Press A to move left                        Press D to move right";
        if(SettingsTracker.axisKeys == false && !onMainMenu)
            TextboxRunText.sentence = "Press Left Arrow for left                     Press Right Arrow for right";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetJoystickNames());


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
            TextboxHoldJumpText.sentence = "Hold " + SettingsTracker.jumpKey.ToString() + " to jump higher";
            TextboxWallJumpText.sentence = "Press " + SettingsTracker.jumpKey.ToString() + " whilst climbing to wall jump";
            TextboxDashText.sentence = "Press " + SettingsTracker.dashKey.ToString() + " and a direction to dash! This ability refreshes when grounded";
        }
    }
}
