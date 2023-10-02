using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public float damage;
    [SerializeField] protected float attackCooldown;
    public bool CanAttack { get; protected set; }

    public Transform projectileSource;
    public Projectile projectilePrefab;

    private void Start()
    {
        CanAttack = true;
    }

    public void Attack(List<Targettable> enemy)
    {
        if (CanAttack)
        {
            StartCoroutine(AttackCoroutine(enemy));
        }
    }

    public virtual IEnumerator AttackCoroutine(List<Targettable> enemy)
    {
        CanAttack = false;

        foreach (var enemyItem in enemy)
        {
            FireProjectile(enemyItem, (target) => target.TakeDamage(damage));
        }
        yield return new WaitForSeconds(attackCooldown);
        CanAttack = true;
    }

    public void FireProjectile(Targettable target, System.Action<Targettable> damageEffect)
    {
        if (projectilePrefab != null)
        {
            var proj = Instantiate(projectilePrefab,
                projectileSource != null ? projectileSource.position : transform.position,
                projectileSource != null ? projectileSource.rotation : transform.rotation, null);

            proj.FlyToTarget(target.transform, () => {
                if (target != null)
                {
                    damageEffect.Invoke(target);
                }
            });
        }
        else
        {
            damageEffect.Invoke(target);
        }
    }

}
