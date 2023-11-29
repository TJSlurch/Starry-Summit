using UnityEngine;

public class PlayerLocationTracker : MonoBehaviour
{
    // attributes for the currently active screen
    private int screen;
    private float screenX;
    private float screenY;
    private float respawnX;
    private float respawnY;

    // boolean which requests new collider
    private bool newScreenRequest = true;

    private void Update()
    {
        // FIXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        StatsTracker.currentProgress = Mathf.RoundToInt(screen / 10 * 100);
        Debug.Log(Mathf.RoundToInt((screen / 10) * 100));
    }

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
