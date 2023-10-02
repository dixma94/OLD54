using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public MoveComponent followTarget;
    public Vector3 cameraOffset = new Vector3(0, 10, 0);
    public float cameraSpeed = 1f;
    public float watchOffset = 4;
    public bool IsHeroDead = false;

    private void Start()
    {
        EntityManager.Instance.TargetKilled += Instance_TargetKilled;
    }

    private void Instance_TargetKilled(Targettable target)
    {
        if (target.targetType == EntityType.Hero)
        {
            IsHeroDead = true;
        }
    }

    void Update()
    {
        if (!IsHeroDead)
        {
            Vector3 targetPosition = followTarget.transform.position + cameraOffset + followTarget.GetCurrentRotateDirection().normalized * watchOffset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
        }
    }
}
