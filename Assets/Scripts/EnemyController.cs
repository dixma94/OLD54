using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float AgroRadiusForTower = 15f;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] AttackComponent attackComponent;
    public EnemyType enemyType;
    private Vector3 DefaultpointToMove;


    // Update is called once per frame
    void Update()
    {
        switch (enemyType)
        {
            case EnemyType.First:
                if(TryAttackTower()) return;
                break;
            case EnemyType.Second:
                break;
            case EnemyType.Third:
                break;
            default:
                break;
        }
    }

    private bool TryAttackTower()
    {
        Targettable[] towers = EntityManager.Instance.GetTowersInRange(transform.position, AgroRadiusForTower);
        Targettable tower = towers
         .OrderBy(item => Vector3.Distance(transform.position, item.transform.position))
         .FirstOrDefault();

        if (tower != null)
        {
            SetPointToMove(tower.transform.position);

        }
        if (true)
        {
            attackComponent.Attack(tower);
            return true;
        }
        return false;
    }

    public void SetPointToMove(Vector3 point)
    {
        agent.SetDestination(point);
    }
    public void SetDefaultPointToMove(Vector3 point)
    {
        DefaultpointToMove = point;
        agent.SetDestination(point);
    }
}
public enum EnemyType
{
    First,
    Second, 
    Third
}
