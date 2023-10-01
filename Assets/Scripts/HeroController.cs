using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class HeroController : MonoBehaviour
{
    private InputControls inputActions;
    [SerializeField] MoveComponent moveComponent;
    [SerializeField] AttackComponent attackComponent;
    [SerializeField] GameObject selectHint;
 
    private Targettable selected;

    private void Awake()
    {
        inputActions = new InputControls();
        inputActions.Input.Enable();
    }



    private void Update()
    {
        Vector2 moveDir = inputActions.Input.Move.ReadValue<Vector2>();
        Vector2 rotateDir = inputActions.Input.Rotate.ReadValue<Vector2>();

        moveComponent.Move(moveDir);
        moveComponent.RotateTo(rotateDir);
        selected =  EnemyInDirection();
        if (selected != null)
        {
            
            selected.Select(selectHint);
            if (inputActions.Input.Action.IsPressed())
            {
                attackComponent.Attack(selected);
            }
           

        }
        else
        {
            selectHint.SetActive(false);
        }

    }

    private Targettable EnemyInDirection()
    {
        var enemies = EntityManager.Instance.GetTargetsysInRadius(transform.position, 5f);


        return enemies
         .Where(item => Vector3.Angle(moveComponent.GetCurrentRotateDirection(), item.transform.position - transform.position) < 35f)
         .OrderBy(item => Vector3.Angle(moveComponent.GetCurrentRotateDirection(), item.transform.position - transform.position))
         .FirstOrDefault();


    }
}
