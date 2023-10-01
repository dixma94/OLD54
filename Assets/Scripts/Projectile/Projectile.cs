using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 initialForce;
    public Vector3 forceDecrement;
    public float speed;

    private float eps = 0.24f;
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
        if(target == null)
        {
            Destroy(gameObject);
        }
        float dist = Vector3.Distance(transform.position, target.transform.position);
        while (Mathf.Abs(Vector3.Distance(transform.position, target.transform.position)) >= eps)
        {
            Vector3 dir = (target.transform.position - transform.position).normalized;
            Vector3 delta = (externalForce + dir * speed) * Time.deltaTime;
            transform.Translate(delta);
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
