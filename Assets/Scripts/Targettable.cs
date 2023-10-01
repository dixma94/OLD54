using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Targettable : MonoBehaviour
{

    public event Action<GameObject> OnChangeHint;
    public EntityType targetType;

    [SerializeField] GameObject point;
    [SerializeField] InteractComponent interactComponent;
    public HealthComponent healthComponent;
    public NavMeshAgent agent;

    public float deathTime = 1f;

    private GameObject selector;
    // Start is called before the first frame update
    void Start()
    {
        EntityManager.Instance.RegisterEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select(GameObject Selector)
    {
        Selector.SetActive(true);
        Selector.transform.position = point.transform.position;
        Selector.transform.parent = point.transform;
        selector = Selector;
    }


    public void Interact()
    {
        if (interactComponent != null)
        {
             interactComponent.Interact(this);
        }
    }

    public void FrezzeDamage(float damage)
    {
        agent.speed = agent.speed * 0.5f;
        healthComponent.currentHealth -= damage;
        if (healthComponent.currentHealth <= 0)
        {
            DestroyTarget();
        }
    }

    public void TakeDamage(float damage)
    {

        healthComponent.currentHealth -= damage;
        if (healthComponent.currentHealth <= 0)
        {
            DestroyTarget();
        }
    }

    public void DestroyTarget()
    {
        EntityManager.Instance.UnRegisterEnemy(this);
        OnChangeHint?.Invoke(selector);
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }
}
