using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MoveComponent : MonoBehaviour
{
    private const float FallSpeed = 100f;
    [SerializeField] private float Speed;
    [SerializeField] CharacterController characterController;
    [SerializeField] GameObject VisualObject;

    private Vector2 rotateDirection;
    private Vector2 moveDirection; 

    public void Move(Vector2 moveDir)
    {
        moveDirection = moveDir;
        Vector3 vector = new Vector3(moveDir.x, 0, moveDir.y);
        characterController.Move(vector * Speed * Time.deltaTime);

        Physics.Raycast(transform.position, Vector3.down,out RaycastHit hitInfo, 0.05f);
        if (hitInfo.collider == null)
        {
            characterController.Move(Vector3.down * FallSpeed * Time.deltaTime);
        }
    }

    public void RotateTo(Vector2 rotateDir)
    {
        if (rotateDir == Vector2.zero)
        {
            rotateDirection = moveDirection;
        }
        else
        {
            rotateDirection = rotateDir;
        }

        Vector3 vector = new Vector3(rotateDirection.x, 0, rotateDirection.y);
        const float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, vector, Time.deltaTime * rotateSpeed);
    }

    public Vector3 GetCurrentRotateDirection()
    {
        return transform.forward;
    }


}
