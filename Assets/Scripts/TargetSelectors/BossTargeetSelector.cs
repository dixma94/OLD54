using System.Linq;
using UnityEngine;

public class BossTargeetSelector : TargetSelector
{
    public override Targettable[] GetTargetsInRange(Vector3 position, float radius)
    {

        return EntityManager.Instance
          .GetEnemiesInRadius(position, radius)
          .OrderBy(item => item.healthComponent.maxHelth).ToArray();

    }
}
