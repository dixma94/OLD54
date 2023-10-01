using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactoryInteractComponent : InteractComponent
{
    [SerializeField] ResourcesUI resources;

    public TowerData towerType;

    public override void Interact(Targettable targettable)
    {
        if (targettable.targetType == EntityType.FactroySlot)
        {
            if (resources.rocksCount >= towerType.rockCost && resources.treesCount >= towerType.woodCost && resources.towerToBuild == 0)
            {
                resources.towerToBuild = towerType.id;
                resources.rocksCount--;
                resources.treesCount--;
                resources.UpdateText();
            }
        }
    }
}
