using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class HeroController : MonoBehaviour
{
    private InputControls inputActions;
    [SerializeField] MoveComponent moveComponent;

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

        var enemy =  EntityManager.Instance.GetEnemysInRadius(transform.position, 5f);


        Enemy[] enemiesInRange =  enemy.Where(item => Vector3.Angle(moveComponent.GetCurrentRotateDirection(), item.transform.position - transform.position) < 35f).ToArray();

        foreach (var item in enemiesInRange)
        {
            
        }
    }
}
