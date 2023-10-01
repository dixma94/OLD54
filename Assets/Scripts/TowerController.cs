using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private AttackComponent attackComponent;
    [SerializeField] private TargetSelector targetSelector;
    public float AttackCoolDown = 2f;

    const float AttackRadius = 10f;
    public TowerVisual visual;

    private void Update()
    {
        if (attackComponent.CanAttack)
        {
            Targettable[] targets =  targetSelector.GetTargetsInRange(transform.position, AttackRadius);
            if (targets.Length > 0 )
            {
                visual.Attack();
                attackComponent.Attack(targets);
            }
        }


    }

}

