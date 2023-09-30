using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public MoveComponent followTarget;
    public Vector3 cameraOffset = new Vector3(0, 10, 0);
    public float cameraSpeed = 1f;
    public float watchOffset = 4;
    void Update()
    {
        Vector3 targetPosition = followTarget.transform.position + cameraOffset + followTarget.GetCurrentRotateDirection().normalized * watchOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}
