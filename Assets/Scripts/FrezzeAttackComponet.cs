using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FrezzeAttackComponet : AttackComponent
{
    public override IEnumerator AttackCoroutine(List<Targettable> enemy)
    {
        CanAttack = false;
        FireProjectile(enemy.FirstOrDefault(), (target) => target.FrezzeDamage(damage));
        yield return new WaitForSeconds(attackCooldown);
        CanAttack = true;
    }
}
