using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerVisual : MonoBehaviour
{
    public Animator animator;

    private int placed = Animator.StringToHash("Placed");
    private int attack = Animator.StringToHash("Attack");

    public bool Placed
    {
        get => animator.GetBool(placed);
        set
        {
            animator.SetBool(placed, value);
        }
    }

    public void Attack()   
    {
        animator.SetTrigger(attack);
    }
}
