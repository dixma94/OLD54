using System.Collections;
using UnityEngine;

public class AttackAllTargetsComponent: AttackComponent
{
    public override IEnumerator AttackCoroutine(Targettable[] enemy)
    {
        CanAttack = false;
        foreach (var enemyItem in enemy)
        {
            if (projectilePrefab != null)
            {
                var proj = Instantiate<Projectile>(projectilePrefab, transform.position, transform.rotation, null);
                proj.FlyToTarget(enemyItem.transform, () => { if (enemyItem != null) enemyItem.TakeDamage(damage); });
            }
            else
            {
                enemyItem.TakeDamage(damage);
            }
        }
        yield return new WaitForSeconds(attackCooldown);
        CanAttack = true;
    }
}
