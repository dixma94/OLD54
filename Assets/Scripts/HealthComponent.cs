using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float currentHealth;
    public float maxHelth;

    private void Start()
    {
        currentHealth = maxHelth;
    }


}
