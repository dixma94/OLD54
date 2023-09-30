using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public static EntityManager Instance;

    private List<Enemy> EnemyList = new List<Enemy>();

    private void Awake()
    {
        Instance = this;

    }

    public void RegisterEnemy(Enemy enemy)
    {
        EnemyList.Add(enemy);
    }
    public void UnRegisterEnemy(Enemy enemy)
    {
        EnemyList.Remove(enemy);
    }

    public Enemy[] GetEnemysInRadius(Vector3 center, float radius)
    {
        List<Enemy> enemies = new List<Enemy>();
        foreach (Enemy enemy in EnemyList)
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
    Tower

}
