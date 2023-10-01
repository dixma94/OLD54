using System.Collections;
using System.Linq;
using UnityEngine;

public class AttackTargetComponent : AttackComponent
{
    public override IEnumerator AttackCoroutine(Targettable[] enemy)
    {
        CanAttack = false;
        enemy.FirstOrDefault().TakeDamage(damage);
        yield return new WaitForSeconds(attackCooldown);
        CanAttack = true;
    }
}
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
