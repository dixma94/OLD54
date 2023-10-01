using System.Linq;
using UnityEngine;

public class FirstTargetSelector: TargetSelector
{
    public override Targettable[] GetTargetsInRange(Vector3 position, float radius)
    {

        return  EntityManager.Instance
          .GetEnemiesInRadius(position, radius)
          .OrderBy(item => Vector3.Distance(position, item.transform.position)).ToArray();

    }
}
