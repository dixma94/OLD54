using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
public class HeroController : MonoBehaviour
{
    [SerializeField] private float BuildRadius = 20f;
    [SerializeField] private float AttackRadius = 20f;
    [SerializeField] private float CollectRadius = 20f;


    [SerializeField] private float Angle = 45f;

    private InputControls inputActions;
    [SerializeField] MoveComponent moveComponent;
    [SerializeField] AttackComponent attackComponent;
    [SerializeField] GameObject selectHint;
 
    private Targettable selectedNow;
    private Targettable selectedLast;


    private bool isMouse = true;

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
        if(rotateDir != Vector2.zero)
        {
            isMouse = false;
        }

        if(isMouse)
        {
            Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector2 mousePos = Mouse.current.position.ReadValue();

            Debug.Log($"{screenPos} {mousePos} {mousePos - screenPos}");
            rotateDir = (mousePos - screenPos).normalized;
        }

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

                attackComponent.Attack(new List<Targettable> { selectedNow });
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
        selectHint.transform.localScale = Vector3.one;
        this.selectHint = selectHint;
    }

    private Targettable TargetInDirection()
    {
        var targets = EntityManager.Instance.GetTargetsInRadius(transform.position, AttackRadius, EntityType.Enemy);
        targets.AddRange(EntityManager.Instance.GetTargetsInRadius(transform.position, BuildRadius, EntityType.FactroySlot));
        targets.AddRange(EntityManager.Instance.GetTargetsInRadius(transform.position, BuildRadius, EntityType.TowerSlot));
        targets.AddRange(EntityManager.Instance.GetTargetsInRadius(transform.position, CollectRadius, EntityType.Rocks));
        targets.AddRange(EntityManager.Instance.GetTargetsInRadius(transform.position, CollectRadius, EntityType.Trees));
        //targets.AddRange(EntityManager.Instance.GetTargetsInRadius(transform.position, BuildRadius, EntityType.Tower));

        var targetsInAngle = targets
         .Where(item => Vector3.Angle(moveComponent.GetCurrentRotateDirection(), item.transform.position - transform.position) < Angle);


        if(isMouse)
        {
            return targetsInAngle.OrderBy(item => Vector3.Distance((Vector2)(Camera.main.WorldToScreenPoint(item.transform.position)), Mouse.current.position.ReadValue())).FirstOrDefault();
        }
        else
        {
            return targetsInAngle.OrderBy(item => Vector3.Angle(moveComponent.GetCurrentRotateDirection(), item.transform.position - transform.position)).FirstOrDefault();
        }
    }
}
