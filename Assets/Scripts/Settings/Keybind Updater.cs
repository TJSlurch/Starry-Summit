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

    TextMeshProUGUI RunControlText;
    TextMeshProUGUI ClimbControlText;
    TextMeshProUGUI JumpControlText;
    TextMeshProUGUI WallHoldControlText;
    TextMeshProUGUI DashControlText;

    void Start()
    {
        RunControlText = RunControlObject.GetComponent<TextMeshProUGUI>();
        ClimbControlText = ClimbControlObject.GetComponent<TextMeshProUGUI>();
        JumpControlText = JumpControlObject.GetComponent<TextMeshProUGUI>();
        WallHoldControlText = WallHoldControlObject.GetComponent<TextMeshProUGUI>();
        DashControlText = DashControlObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SettingsTracker.axisKeys == true)
        {
            RunControlText.text = "A / D";
            ClimbControlText.text = "W / S";
        }
        else
        {
            RunControlText.text = "Left / Right";
            ClimbControlText.text = "Up / Down";
        }

        JumpControlText.text = SettingsTracker.jumpKey.ToString();
        WallHoldControlText.text = SettingsTracker.climbKey.ToString();
        DashControlText.text = SettingsTracker.dashKey.ToString();
    }
}
