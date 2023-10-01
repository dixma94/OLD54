using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public float damage;
    [SerializeField] private float attackCooldown;
    public bool CanAttack { get; private set; }

    public Projectile projectilePrefab;

    private void Start()
    {
        CanAttack = true;
    }

    public void Attack(Targettable enemy)
    {
        if (CanAttack)
        {
            StartCoroutine(AttackCoroutine(enemy));
        }
    }

    private IEnumerator AttackCoroutine(Targettable enemy)
    {
        CanAttack = false;
        if(projectilePrefab != null)
        {
            var projectile = Instantiate<Projectile>(projectilePrefab, transform.position, transform.rotation, null);
            projectile.FlyToTarget(enemy.transform, () => { if (enemy != null) { enemy.TakeDamage(damage); } });
        }
        else
        {
            enemy.TakeDamage(damage);
        }
        yield return new WaitForSeconds(attackCooldown);
        CanAttack = true;
    }


}
