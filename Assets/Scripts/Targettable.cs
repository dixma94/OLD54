using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targettable : MonoBehaviour
{
    public event Action TargetKilled;
    public EntityType TargetEntity;
    [SerializeField] GameObject point;
    [SerializeField] HealthComponent health;
    // Start is called before the first frame update
    void Start()
    {
        EntityManager.Instance.RegisterEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select(GameObject gameObject)
    {
        gameObject.transform.position = point.transform.position;
    }



    public void TakeDamage(float damage)
    {
        health.currentHealth -= damage;
        if (health.currentHealth <= 0)
        {
            EntityManager.Instance.UnRegisterEnemy(this);
            TargetKilled?.Invoke();
            Destroy(gameObject);
        }
    }
}
