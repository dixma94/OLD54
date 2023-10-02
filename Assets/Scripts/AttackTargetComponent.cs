using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackTargetComponent : AttackComponent
{
    public override IEnumerator AttackCoroutine(List<Targettable> enemy)
    {
        CanAttack = false;
        var enemyItem = enemy.FirstOrDefault();

        FireProjectile(enemyItem, (target) => target.TakeDamage(damage));

        yield return new WaitForSeconds(attackCooldown);
        CanAttack = true;
    }
}
