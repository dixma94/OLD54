using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public float damage;
    [SerializeField] private float attackCooldown;
    public bool CanAttack { get; private set; }

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
        enemy.TakeDamage(damage);
        yield return new WaitForSeconds(attackCooldown);
        CanAttack = true;
    }


}
