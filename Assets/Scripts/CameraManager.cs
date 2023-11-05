using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public PlayerLocationTracker tracker;

    private void Start()
    {
       
    }

    private void Update()
    {
        transform.position = new Vector3(tracker.getScreenX(), tracker.getScreenY(), transform.position.z);
        
    }
}
