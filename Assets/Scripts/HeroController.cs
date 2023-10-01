using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    private const float Radius = 5f;
    private const float Angle = 45f;

    private InputControls inputActions;
    [SerializeField] MoveComponent moveComponent;
    [SerializeField] AttackComponent attackComponent;
    [SerializeField] GameObject selectHint;
 
    private Targettable selectedNow;
    private Targettable selectedLast;

    private void Awake()
    {
        inputActions = new InputControls();
        inputActions.Input.Enable();
        selectHint.SetActive(false);
    }



    private void Update()
    {
        Vector2 moveDir = inputActions.Input.Move.ReadValue<Vector2>();
        Vector2 rotateDir = inputActions.Input.Rotate.ReadValue<Vector2>();

        moveComponent.Move(moveDir);
        moveComponent.RotateTo(rotateDir);
        selectedNow = TargetInDirection();
       
        if (selectedNow != null)
        {
            if (selectedNow != selectedLast)
            {
                if (selectedLast != null)
                {
                    selectedLast.OnChangeHint -= ChangeHintPosition;
                }
                selectedLast = selectedNow;
                selectedNow.Select(selectHint);
                selectedNow.OnChangeHint += ChangeHintPosition;
            }
            
            if (inputActions.Input.Action.IsPressed())
            {

                attackComponent.Attack(new Targettable[] { selectedNow });
            }
            if (inputActions.Input.Action2.IsPressed())
            {
                selectedNow.Interact();
            }
        }
        else
        {
            ChangeHintPosition(selectHint);
            selectedLast = null;
        }


    }

    private void ChangeHintPosition(GameObject selectHint)
    {
        selectHint.SetActive(false);
        selectHint.transform.parent = transform;
        this.selectHint = selectHint;
    }

    private Targettable TargetInDirection()
    {
        var enemies = EntityManager.Instance.GetTargetsysInRadius(transform.position, Radius);


        return enemies
         .Where(item => Vector3.Angle(moveComponent.GetCurrentRotateDirection(), item.transform.position - transform.position) < Angle)
         .OrderBy(item => Vector3.Angle(moveComponent.GetCurrentRotateDirection(), item.transform.position - transform.position))
         .FirstOrDefault();


    }
}
