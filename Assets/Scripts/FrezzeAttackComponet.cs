using System.Collections;
using System.Linq;
using UnityEngine;

public class FrezzeAttackComponet : AttackComponent
{
    public override IEnumerator AttackCoroutine(Targettable[] enemy)
    {
        CanAttack = false;
        enemy.FirstOrDefault().FrezzeDamage(damage);
        yield return new WaitForSeconds(attackCooldown);
        CanAttack = true;
    }
}
