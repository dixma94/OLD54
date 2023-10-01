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
    private int die = Animator.StringToHash("Death");

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
        set => animator.SetFloat(speed, value);
    }

    public void Die()
    {
        isDead = true;
        animator.SetTrigger(die);
    }
}
