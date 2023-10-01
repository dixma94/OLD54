﻿using System.Collections;
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
