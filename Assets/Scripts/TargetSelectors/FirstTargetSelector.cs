using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FirstTargetSelector: TargetSelector
{
    public override List<Targettable> GetTargetsInRange(Vector3 position, float radius)
    {

        return  EntityManager.Instance
          .GetTargetsInRadius(position, radius, EntityType.Enemy)
          .OrderBy(item => Vector3.Distance(position, item.transform.position)).ToList();

    }
}
