using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private const float RangeForAttack = 3f;
    private const float IdleCooldown = 1f;
    [SerializeField] private float AgroRadius = 3f;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] AttackComponent attackComponent;
    public EnemyType enemyType;
    private Vector3 DefaultpointToMove;
    private Targettable CurrentTower;
    private Targettable Player;
    private bool IsOnColldown = false;

    public EnemyVisuals visuals;
    public HealthComponent health;

    // Update is called once per frame
    void Update()
    {
        switch (enemyType)
        {
            case EnemyType.First:
                if (!IsOnColldown) 
                {
                    StartCoroutine(CooldownCoroutine());
                    FirstBehaviour();
                }
                break;
            case EnemyType.Second:
                if (!IsOnColldown)
                {
                    StartCoroutine(CooldownCoroutine());
                    SecondBehaviour();
                }
                break;
            case EnemyType.Third:
                break;
            default:
                break;
        }

        visuals.Speed = agent.velocity.magnitude;

        if(health.currentHealth <= 0)
        {
            visuals.Die();
            StopAllCoroutines();
            IsOnColldown = true;
        }
    }

    private IEnumerator CooldownCoroutine()
    {
        IsOnColldown = true;
        yield return new WaitForSeconds(IdleCooldown);
        IsOnColldown = false;
    }

    private void SecondBehaviour()
    {
        if (Player == null)
        {
            SetPointToMove(DefaultpointToMove);
            Player = FindPlayer();
        }
        else
        {
            if (Vector3.Distance(Player.transform.position, transform.position)>AgroRadius)
            {
                Player = null;
                SetPointToMove(DefaultpointToMove);
            }
            else
            {
                SetPointToMove(Player.transform.position);
                AttackTarget(Player);
            }
            
            
        }
    }

    private void FirstBehaviour()
    {
        if (CurrentTower == null)
        {
            SetPointToMove(DefaultpointToMove);
            CurrentTower = FindTower();
        }
        else
        {
            SetPointToMove(CurrentTower.transform.position);
            AttackTarget(CurrentTower);
        }
    }

    private Targettable FindTower()
    {
        return EntityManager.Instance.GetTowersInRange(transform.position, AgroRadius)
            .OrderBy(item => Vector3.Distance(transform.position, item.transform.position))
         .FirstOrDefault(); 

    }

    private Targettable FindPlayer()
    {
        return EntityManager.Instance.GetHeroInRange(transform.position, AgroRadius);

    }
    private void AttackTarget(Targettable target)
    {
        if (attackComponent.CanAttack) 
        {
            if (Vector3.Distance(transform.position,target.transform.position)<= RangeForAttack)
            {
                visuals.Attack();
                attackComponent.Attack(new Targettable[] {target});
            }
        }
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
