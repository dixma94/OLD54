using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public float damage;
    [SerializeField] protected float attackCooldown;
    public bool CanAttack { get; protected set; }

    public Projectile projectilePrefab;

    private void Start()
    {
        CanAttack = true;
    }

    public void Attack(Targettable[] enemy)
    {
        if (CanAttack)
        {
            StartCoroutine(AttackCoroutine(enemy));
        }
    }

    public virtual IEnumerator AttackCoroutine(Targettable[] enemy)
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
