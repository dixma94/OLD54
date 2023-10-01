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

        if (projectilePrefab != null)
        {
            var proj = Instantiate<Projectile>(projectilePrefab, transform.position, transform.rotation, null);
            proj.FlyToTarget(boss.transform, () => { if (boss != null) {
                    boss.TakeDamage(damage);
                    var others = EntityManager.Instance.GetEnemiesInRadius(boss.transform.position, aoeRadius);
                    foreach (var other in others)
                    {
                        other.TakeDamage(damage / 2);
                    }
                } });
        }
        else
        {
            boss.TakeDamage(damage);
            var others = EntityManager.Instance.GetEnemiesInRadius(boss.transform.position, aoeRadius);
            foreach (var other in others)
            {
                other.TakeDamage(damage / 2);
            }
        }

 
        yield return new WaitForSeconds(attackCooldown);
        CanAttack = true;
    }
}
