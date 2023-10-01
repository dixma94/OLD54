using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TowerSlotInteractComponent : InteractComponent
{
    [SerializeField] ResourcesUI resources;

    private int TowerInSlot;
    public bool CanBuildInThisSlot = true;

    public TowerData[] towers;

    public override void Interact(Targettable targettable)
    {
        if (targettable.targetType == EntityType.TowerSlot)
        {
            if (CanBuildInThisSlot && resources.towerToBuild != 0)
            {
                var towerData = towers.FirstOrDefault((tower) => tower.id == resources.towerToBuild);

                var newTower = Instantiate(towerData.prefab, transform.position, Quaternion.identity, transform);
                newTower.visual.Placed = true;

                TowerInSlot = newTower.GetInstanceID();

                CanBuildInThisSlot = false;
                resources.towerToBuild = 0;
                EntityManager.Instance.TargetKilled += TargetKilled;
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
