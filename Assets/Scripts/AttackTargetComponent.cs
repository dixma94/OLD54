using System.Collections;
using System.Linq;
using UnityEngine;

public class AttackTargetComponent : AttackComponent
{
    public override IEnumerator AttackCoroutine(Targettable[] enemy)
    {
        CanAttack = false;
        var enemyItem = enemy.FirstOrDefault();

        if (projectilePrefab != null)
        {
            var proj = Instantiate<Projectile>(projectilePrefab, transform.position, transform.rotation, null);
            proj.FlyToTarget(enemyItem.transform, () => { if (enemyItem != null) enemyItem.TakeDamage(damage); });
        }
        else
        {
            enemyItem.TakeDamage(damage);
        }
        yield return new WaitForSeconds(attackCooldown);
        CanAttack = true;
    }
}
