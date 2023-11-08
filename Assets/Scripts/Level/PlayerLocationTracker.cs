using UnityEngine;

public class PlayerLocationTracker : MonoBehaviour
{
    // attributes for the currently active screen
    private int screen;
    private float screenX;
    private float screenY;

    // boolean which requests new collider
    private bool newScreenRequest = true;

    // accessor and mutator methods for the active screen
    public void setScreen(int value)
    {
        screen = value;
    }
    public int getScreen()
    {
        return screen;
    }
    public void setScreenRequest(bool value)
    {
        newScreenRequest = value;
    }
    public bool GetScreenRequest()
    {
        return newScreenRequest;
    }
    public void setScreenX(float value)
    {
        screenX = value;
    }
    public float getScreenX()
    {
        return screenX;
    }
    public void setScreenY(float value)
    {
        screenY = value;
    }
    public float getScreenY()
    {
        return screenY;
    }
}
