using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targettable : MonoBehaviour
{

    public event Action<GameObject> OnChangeHint;
    public EntityType targetType;

    [SerializeField] GameObject point;
    [SerializeField] HealthComponent healthComponent;
    [SerializeField] InteractComponent interactComponent;


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
        Destroy(gameObject);
    }
}
