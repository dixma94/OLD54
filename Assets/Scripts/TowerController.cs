using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private AttackComponent attackComponent;
    public float AttackCoolDown = 2f;
    private Targettable CurrentTarget;

    const float AttackRadius = 10f;

    private void Update()
    {
        if (attackComponent.CanAttack)
        {
            if (CurrentTarget == null)
            {
                GetNearTarget();
            }

            if (CurrentTarget != null)
            {
                if (CanAttackTarget(CurrentTarget))
                {
                    attackComponent.Attack(CurrentTarget);
                }

            }
        }


    }

    private bool CanAttackTarget(Targettable targettable)
    {
       return EntityManager.Instance.GetTargetsysInRadius(transform.position, AttackRadius).Contains(targettable);
    }

    private void GetNearTarget()
    {

        CurrentTarget = EntityManager.Instance.GetTargetsysInRadius(transform.position, AttackRadius)
            .OrderBy(item => Vector3.Distance(transform.position, item.transform.position))
            .FirstOrDefault();
        CurrentTarget.TargetKilled += CurrentTarget_TargetKilled;
    }

    private void CurrentTarget_TargetKilled()
    {
        CurrentTarget = null;
    }
}
