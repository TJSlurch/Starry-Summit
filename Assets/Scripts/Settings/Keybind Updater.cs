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

    private bool usingKeyboard = true;

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
        if (SettingsTracker.axisKeys == false && !onMainMenu)
            TextboxRunText.sentence = "Press Left Arrow for left                     Press Right Arrow for right";
    }

    private void detectInputMethod()
    {
        if (Input.GetAxis("KeyboardInput") != 0) // if keyboard input detected
        {
            usingKeyboard = true; // set keyboard to true
        }
        if (Input.GetAxis("ControllerInput") != 0) // if controller input detected
        {
            usingKeyboard = false; // set keyboard to false
        }
    }

    void Update()
    {
        detectInputMethod(); // every frame check which input method is being used

        if (usingKeyboard)
        {
            updateTextToKeyboard(); // display keyboard controls
        }
        else
        {
            updateTextToController(); // display controller controls
        }
    }

    private void updateTextToKeyboard()
    {
        if (SettingsTracker.axisKeys == true) // if using WASD
        {
            RunControlText.text = "A / D"; // update input on the menu
            ClimbControlText.text = "W / S"; // update input on the menu
            if (!onMainMenu)  // update in game tutorials
            {
                TextboxRunText.sentence = "Press A to move left                        Press D to move right";
                TextboxClimbText.sentence = "Hold " + SettingsTracker.climbKey.ToString() + " to grab onto a wall!              then press W or S to climb,";
            }
        }
        else // If using arrow keys
        {
            RunControlText.text = "Left / Right"; // update input on the menu
            ClimbControlText.text = "Up / Down"; // update input on the menu
            if (!onMainMenu) // update in game tutorials
            {
                TextboxRunText.sentence = "Press Left Arrow for left                     Press Right Arrow for right";
                TextboxClimbText.sentence = "Hold " + SettingsTracker.climbKey.ToString() + " to grab onto a wall!              then press up arrow or down arrow to climb,";
            }
        }

        JumpControlText.text = SettingsTracker.jumpKey.ToString(); // update inputs on the menu
        WallHoldControlText.text = SettingsTracker.climbKey.ToString(); // update input on the menu
        DashControlText.text = SettingsTracker.dashKey.ToString(); // update input on the menu
        if (!onMainMenu) // update in game tutorials
        {
            TextboxJumpText.sentence = "Press " + SettingsTracker.jumpKey.ToString() + " to jump";
            TextboxHoldJumpText.sentence = "Hold " + SettingsTracker.jumpKey.ToString() + " to jump higher";
            TextboxWallJumpText.sentence = "Press " + SettingsTracker.jumpKey.ToString() + " whilst climbing to wall jump";
            TextboxDashText.sentence = "Press " + SettingsTracker.dashKey.ToString() + " and a direction to dash! This ability refreshes when grounded";
        }
    }

    private void updateTextToController()
    {
        RunControlText.text = "Left Stick";  // update inputs on the menu
        ClimbControlText.text = "Left Stick";
        JumpControlText.text = "A";
        WallHoldControlText.text = "LT / RT";
        DashControlText.text = "X";
        if (!onMainMenu)  // update in game tutorials
        {
            TextboxRunText.sentence = "Use the left stick to move";
            TextboxClimbText.sentence = "Hold LT or RT to grab onto a wall, then use the left stick to climb!";
            TextboxJumpText.sentence = "Press A to jump";
            TextboxHoldJumpText.sentence = "Hold A to jump higher";
            TextboxWallJumpText.sentence = "Press A whilst on a wall to wall jump";
            TextboxDashText.sentence = "Press X and a direction to dash! This ability refreshes when grounded";
        }
    }
}
