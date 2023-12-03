using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsTracker : MonoBehaviour
{
    // keybinds for the three moves
    public static KeyCode jumpKey = KeyCode.Space;
    public static KeyCode dashKey = KeyCode.K;
    public static KeyCode climbKey = KeyCode.L;

    // true = WASD, false = Arrow Keys
    public static bool axisKeys = true;

    // time slowing aid
    public static float AerialAidMultiplier = 1f;

    // speedrun timer toggle
    public static bool timerActive = false;
}
