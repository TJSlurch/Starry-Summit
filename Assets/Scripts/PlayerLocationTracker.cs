using UnityEngine;

public class PlayerLocationTracker : MonoBehaviour
{
    private int screen;
    private bool newScreenRequest;
    private float screenX;
    private float screenY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
