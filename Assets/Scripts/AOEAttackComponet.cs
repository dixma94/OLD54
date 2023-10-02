using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AOEAttackComponet : AttackComponent
{
    private const float aoeRadius = 3f;

    public override IEnumerator AttackCoroutine(List<Targettable> enemy)
    {
        var boss = enemy.FirstOrDefault();
        CanAttack = false;

        FireProjectile(boss, (target) =>
        {
            if(target != null)
            {
                target.TakeDamage(damage);
                var others = EntityManager.Instance.GetTargetsInRadius(target.transform.position, aoeRadius, EntityType.Enemy);
                foreach (var other in others)
                {
                    other.TakeDamage(damage / 2);
                }
            }
        }
        );

        yield return new WaitForSeconds(attackCooldown);
        CanAttack = true;
    }
}
