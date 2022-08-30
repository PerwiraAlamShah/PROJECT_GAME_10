using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform cameraTarget;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);
    [Range(1, 10)]
    public float smoothFactor;


    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        cameraTarget.position = smoothPosition;
    }
}
