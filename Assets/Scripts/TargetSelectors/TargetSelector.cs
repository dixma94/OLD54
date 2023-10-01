using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetSelector : MonoBehaviour
{
    public virtual Targettable[] GetTargetsInRange(Vector3 position, float radius)
    {
        return EntityManager.Instance.GetEnemiesInRadius(position, radius);
    }
}
