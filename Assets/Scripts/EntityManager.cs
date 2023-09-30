using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public static EntityManager Instance;

    private List<Targettable> EnemyList = new List<Targettable>();
    private List<Targettable> TowerList = new List<Targettable>();
    private List<Targettable> HeroList = new List<Targettable>();

    private void Awake()
    {
        Instance = this;

    }

    public void RegisterEnemy(Targettable target)
    {
        switch (target.TargetEntity)
        {
            case EntityType.Enemy:
                EnemyList.Add(target);
                break;
            case EntityType.Tower:
                TowerList.Add(target);
                break;
            case EntityType.Hero:
                HeroList.Add(target);
                break;
            default:
                break;
        }
        
    }
    public void UnRegisterEnemy(Targettable target)
    {
        switch (target.TargetEntity)
        {
            case EntityType.Enemy:
                EnemyList.Remove(target);
                break;
            case EntityType.Tower:
                TowerList.Remove(target);
                break;
            case EntityType.Hero:
                HeroList.Remove(target);
                break;
            default:
                break;
        }
    }

    public Targettable[] GetTargetsysInRadius(Vector3 center, float radius)
    {
        List<Targettable> targettablesInRadius = new List<Targettable>();
        List<Targettable> targettables = EnemyList;
        targettables.AddRange(TowerList);
        foreach (Targettable enemy in targettables)
        {
            if (Vector3.Distance(enemy.transform.position, center)<=radius)
            {
                targettablesInRadius.Add(enemy) ;
            }
        }
        return targettablesInRadius.ToArray();
    }
}

public enum EntityType
{
    Enemy,
    Tower,
    Hero

}
