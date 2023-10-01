using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class EntityManager : MonoBehaviour
{
    public static EntityManager Instance;

    public event Action<Targettable> TargetKilled;

    private List<Targettable> EnemyList = new List<Targettable>();
    private List<Targettable> TowerList = new List<Targettable>();
    private List<Targettable> TreesList = new List<Targettable>();
    private List<Targettable> RocksList = new List<Targettable>();
    private List<Targettable> TowerSlotList = new List<Targettable>();
    private List<Targettable> FactorySlotList = new List<Targettable>();

    private void Awake()
    {
        Instance = this;

    }

    public void RegisterEnemy(Targettable target)
    {
        switch (target.targetType)
        {
            case EntityType.Enemy:
                EnemyList.Add(target);

                break;
            case EntityType.Tower:
                TowerList.Add(target);
                break;
            case EntityType.Hero:
                break;
            case EntityType.Trees:
                TreesList.Add(target);
                break;
            case EntityType.Rocks:
                RocksList.Add(target);
                break;
            case EntityType.TowerSlot:
                TowerSlotList.Add(target);
                break;
            case EntityType.FactroySlot:
                FactorySlotList.Add(target);
                break;
            default:
                break;
        }

    }
    public void UnRegisterEnemy(Targettable target)
    {
        TargetKilled?.Invoke(target);

        switch (target.targetType)
        {
            case EntityType.Enemy:
                EnemyList.Remove(target);
                break;
            case EntityType.Tower:
                TowerList.Remove(target);
                break;
            case EntityType.Hero:
                break;
            case EntityType.Trees:
                TreesList.Remove(target);
                break;
            case EntityType.Rocks:
                RocksList.Remove(target);
                break;
            case EntityType.TowerSlot:
                TowerSlotList.Remove(target);
                break;
            case EntityType.FactroySlot:
                FactorySlotList.Remove(target);   
                break;
            default:
                break;
        }
    }

    public Targettable[] GetTargetsysInRadius(Vector3 center, float radius)
    {
        List<Targettable> targettablesInRadius = new List<Targettable>();
        List<Targettable> targettables = new List<Targettable>();
        targettables.AddRange(TowerList);
        targettables.AddRange(EnemyList);
        targettables.AddRange(TreesList);
        targettables.AddRange(RocksList);
        targettables.AddRange(TowerSlotList);
        targettables.AddRange(FactorySlotList);
        foreach (Targettable enemy in targettables)
        {
            if (Vector3.Distance(enemy.transform.position, center)<=radius)
            {
                targettablesInRadius.Add(enemy) ;
            }
        }
        return targettablesInRadius.ToArray();
    }

    public Targettable[] GetEnemiesInRadius(Vector3 center, float radius)
    {
        List<Targettable> targettablesInRadius = new List<Targettable>();
        foreach (Targettable enemy in EnemyList)
        {
            if (Vector3.Distance(enemy.transform.position, center) <= radius)
            {
                targettablesInRadius.Add(enemy);
            }
        }
        return targettablesInRadius.ToArray();
    }

    public Targettable[] GetTowersInRange(Vector3 center, float radius)
    {
        List<Targettable> targettablesInRadius = new List<Targettable>();
        foreach (Targettable enemy in TowerList)
        {
            if (Vector3.Distance(enemy.transform.position, center) <= radius)
            {
                targettablesInRadius.Add(enemy);
            }
        }
        return targettablesInRadius.ToArray();
    }
}

public enum EntityType
{
    Enemy,
    Tower,
    Hero,
    Trees,
    Rocks,
    TowerSlot,
    FactroySlot

}
