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

    private Dictionary<EntityType, List<Targettable>> entries = new Dictionary<EntityType, List<Targettable>>();

    private void Awake()
    {
        Instance = this;

    }

    public void RegisterEnemy(Targettable target)
    {
        if(!entries.ContainsKey(target.targetType))
        {
            entries.Add(target.targetType, new List<Targettable>());
        }

        entries[target.targetType].Add(target);
    }
    public void UnRegisterEnemy(Targettable target)
    {
        TargetKilled?.Invoke(target);

        if (!entries.ContainsKey(target.targetType))
        {
            entries.Add(target.targetType, new List<Targettable>());
        }
        entries[target.targetType].Remove(target);
    }

    public List<Targettable> GetTargetsInRadius(Vector3 center, float radius, EntityType type)
    {
        List<Targettable> targettablesInRadius = new List<Targettable>();

        if(entries.ContainsKey(type))
        {
            foreach (Targettable entry in entries[type])
            {
                if (Vector3.Distance(entry.transform.position, center) <= radius)
                {
                    targettablesInRadius.Add(entry);
                }
            }
        }
        return targettablesInRadius;
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
    FactroySlot,
    Factory,

}
