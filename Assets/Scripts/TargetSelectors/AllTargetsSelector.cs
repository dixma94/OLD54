using UnityEngine;

public class AllTargetsSelector: TargetSelector 
{
    public override Targettable[] GetTargetsInRange(Vector3 position, float radius)
    {
        return EntityManager.Instance
         .GetEnemiesInRadius(position, radius);
    }
}
