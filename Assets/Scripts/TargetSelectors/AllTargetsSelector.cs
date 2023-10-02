using System.Collections.Generic;
using UnityEngine;

public class AllTargetsSelector: TargetSelector 
{
    public override List<Targettable> GetTargetsInRange(Vector3 position, float radius)
    {
        return EntityManager.Instance
         .GetTargetsInRadius(position, radius, EntityType.Enemy);
    }
}
