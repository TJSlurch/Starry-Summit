using UnityEngine;

public class PlayerLocationTracker : MonoBehaviour
{
    // attributes for the currently active screen
    private float screen;
    private float screenX;
    private float screenY;
    private float respawnX;
    private float respawnY;

    // boolean which requests new collider
    private bool newScreenRequest = true;

    // number of screens (to be set when level is finalised)
    private int numOfScreens = 15;

    private void Update()
    {
        // finds the percentage of the level completed
        StatsTracker.currentProgress = Mathf.RoundToInt(screen / numOfScreens * 100);
    }

    // accessor and mutator methods for the active screen
    public void setScreen(int value)
    {
        screen = value;
    }
    public int getScreen()
    {
        return Mathf.RoundToInt(screen);
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

    public void setRespawnX(float value)
    {
        respawnX = value;
    }
    public float getRespawnX()
    {
        return respawnX;
    }
    public void setRespawnY(float value)
    {
        respawnY = value;
    }
    public float getRespawnY()
    {
        return respawnY;
    }
}
