using System.Linq;
using UnityEngine;

public class FastTargetSelector : TargetSelector
{
    public override Targettable[] GetTargetsInRange(Vector3 position, float radius)
    {

        return EntityManager.Instance
          .GetEnemiesInRadius(position, radius)
          .OrderBy(item => item.agent.speed).ToArray();

    }
}
