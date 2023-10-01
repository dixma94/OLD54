using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualController : MonoBehaviour
{
    public Animator animator;

    private int facingAngle = Animator.StringToHash("FacingAngle");
    private int facingSide = Animator.StringToHash("FacingSide");
    private int speed = Animator.StringToHash("Speed");

    public float FacingAngle
    {
        get => animator.GetFloat(facingAngle);
        set
        {
            animator.SetFloat(facingAngle, value);
        }
    }

    public float FacingSide
    {
        get => animator.GetFloat(facingSide);
        set
        {
            animator.SetFloat(facingSide, value - 1);
            animator.SetFloat(facingSide, value + 1); 
        }
    }

    public float Speed
    {
        get => animator.GetFloat(speed);
        set 
        {
            animator.SetFloat(speed, value);
        }
    }
}
