using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public PlayerLocationTracker tracker;

    [SerializeField] private float speed = 2.5f;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(tracker.getScreenX(), tracker.getScreenY(), transform.position.z), speed);
    }
}
