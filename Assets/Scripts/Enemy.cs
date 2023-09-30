using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject visual;
    // Start is called before the first frame update
    void Start()
    {
        EntityManager.Instance.RegisterEnemy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {
        visual.SetActive(true);
    }

    public void Deselect()
    {
        visual.SetActive(false);
    }
}
