using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public HealthComponent health;
    public UnityEngine.UI.Image indicator;

    private float maxWidth;
    private void Start()
    {
        maxWidth = 0.75f * 10 + 0.25f;
        if(health == null)
        {
            health = GetComponentInParent <HealthComponent>();
        }
    }
    private void Update()
    {
        if(health != null)
        {
            float width = 0.75f * health.currentHealth + 0.25f;
            if(width > maxWidth)
            {
                indicator.transform.localScale = new Vector2(maxWidth / width, 1);
            }
            indicator.rectTransform.sizeDelta = new Vector2(width, 1);
        }
    }

}
