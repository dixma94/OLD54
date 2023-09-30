using System.Collections;
using System.Collections.Generic;
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

    public Targettable[] GetEnemysInRadius(Vector3 center, float radius)
    {
        List<Targettable> enemies = new List<Targettable>();
        foreach (Targettable enemy in EnemyList)
        {
            if (Vector3.Distance(enemy.transform.position, center)<=radius)
            {
                enemies.Add(enemy) ;
            }
        }
        return enemies.ToArray();
    }
}

public enum EntityType
{
    Enemy,
    Tower,
    Hero

}
