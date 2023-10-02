using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisuals : MonoBehaviour
{
    private bool isDead = false;

    public Animator animator;

    private int rand = Animator.StringToHash("Rand");
    private int speed = Animator.StringToHash("Speed");
    private int attack = Animator.StringToHash("Attack");
    private int die = Animator.StringToHash("Dead");

    public void Attack()
    {
        if(isDead)
        {
            return;
        }

        animator.SetFloat(rand, Random.Range(1, 3));
        animator.SetTrigger(attack);
    }

    public float Speed
    {
        get => animator.GetFloat(speed);
        set => animator.SetFloat(speed, isDead ? 0 : value);
    }

    public void Die()
    {
        if(isDead)
        {
            return;
        }

        isDead = true;
        animator.SetTrigger(die);
    }
}
