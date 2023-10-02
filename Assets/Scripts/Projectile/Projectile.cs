using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 initialForce;
    public Vector3 forceDecrement;
    public float speed;

    private float eps = 0.1f;
    private Vector3 externalForce;

    private Transform target;
    private System.Action onReach;

    public void FlyToTarget(Transform target, System.Action onReach)
    {
        externalForce = initialForce;
        this.target = target;
        this.onReach = onReach;
        StartCoroutine(nameof(FlyCoroutine));
    }

    private IEnumerator FlyCoroutine()
    {
        Vector3 targetPosition = Vector3.zero;

        try
        {
            targetPosition = target.position;
        }
        catch
        {
            Destroy(gameObject);
        }

        float dist = Vector3.Distance(transform.position, targetPosition);
        while (Mathf.Abs(Vector3.Distance(transform.position, targetPosition)) >= eps)
        {
            Vector3 dir = (targetPosition - transform.position).normalized;
            Debug.DrawRay(transform.position, dir, Color.black);
            Vector3 delta = (externalForce + dir * speed) * Time.deltaTime;
            Debug.DrawRay(transform.position, delta, Color.white);

            transform.position += delta;
            transform.LookAt(target);

            externalForce -= forceDecrement * Time.deltaTime;
            if(externalForce.y < 0)
            {
                externalForce.y = 0;
            }
            yield return new WaitForEndOfFrame();
        }
        onReach.Invoke();
        Destroy(gameObject);
    }
}
