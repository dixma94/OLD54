using System.Collections;
using System.Linq;
using UnityEngine;

public class AOEAttackComponet : AttackComponent
{
    private const float aoeRadius = 3f;

    public override IEnumerator AttackCoroutine(Targettable[] enemy)
    {
        var boss = enemy.FirstOrDefault();
        CanAttack = false;
        boss.TakeDamage(damage);
        var others =  EntityManager.Instance.GetEnemiesInRadius(boss.transform.position, aoeRadius);
        foreach (var other in others)
        {
            other.TakeDamage(damage/2);
        }
        yield return new WaitForSeconds(attackCooldown);
        CanAttack = true;
    }
}
