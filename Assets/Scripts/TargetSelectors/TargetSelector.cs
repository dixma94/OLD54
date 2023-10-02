using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetSelector : MonoBehaviour
{
    public virtual List<Targettable> GetTargetsInRange(Vector3 position, float radius)
    {
        return EntityManager.Instance.GetTargetsInRadius(position, radius, EntityType.Enemy);
    }
}
