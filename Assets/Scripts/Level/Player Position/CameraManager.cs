using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public PlayerLocationTracker tracker;

    [SerializeField] private float speed = 3f;

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(tracker.getScreenX(), tracker.getScreenY(), transform.position.z), speed);
    }
}
