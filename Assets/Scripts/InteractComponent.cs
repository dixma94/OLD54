using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractComponent : MonoBehaviour
{
    [SerializeField] GameObject objectToInteract;
    [SerializeField] ResourcesUI resources;
    private int TowerInSlot;

    public bool CanBuildInThisSlot = true;

    public void Interact(Targettable targettable)
    {
        if (targettable.targetType == EntityType.TowerSlot)
        {
            if (CanBuildInThisSlot &&resources.HaveTowerToBuild)
            {
                TowerInSlot = Instantiate(objectToInteract, transform.position, Quaternion.identity, transform).GetInstanceID();
                CanBuildInThisSlot = false;
                resources.HaveTowerToBuild = false;
                EntityManager.Instance.TargetKilled += TargetKilled;
            }
        }
        if (targettable.targetType == EntityType.FactroySlot)
        {
            if (resources.rocksCount >= 1 && resources.treesCount>=1 && !resources.HaveTowerToBuild)
            {
                resources.HaveTowerToBuild = true;
                resources.rocksCount--;
                resources.treesCount--;
                resources.UpdateText();
            }
        }

    }

    private void TargetKilled(Targettable target)
    {
 
        if (TowerInSlot == target.gameObject.GetInstanceID())
        {
            CanBuildInThisSlot = true;
        }
    }
}
