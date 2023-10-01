using System.Collections;
using UnityEngine;

public class AttackAllTargetsComponent: AttackComponent
{
    public override IEnumerator AttackCoroutine(Targettable[] enemy)
    {
        CanAttack = false;
        foreach (var enemyItem in enemy)
        {
            enemyItem.TakeDamage(damage);
        }
        yield return new WaitForSeconds(attackCooldown);
        CanAttack = true;
    }
}
