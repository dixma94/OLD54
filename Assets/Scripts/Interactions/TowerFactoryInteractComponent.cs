using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactoryInteractComponent : InteractComponent
{
    [SerializeField] ResourcesUI resources;

    public TowerData towerType;

    public TMPro.TextMeshProUGUI woodCost;
    public TMPro.TextMeshProUGUI rockCost;

    public override void Interact(Targettable targettable)
    {
        if (targettable.targetType == EntityType.FactroySlot)
        {
            if (resources.rocksCount >= towerType.rockCost && resources.treesCount >= towerType.woodCost && resources.towerToBuild == 0)
            {
                resources.towerToBuild = towerType.id;
                resources.rocksCount -= towerType.rockCost;
                resources.treesCount -= towerType.woodCost;
                resources.UpdateText();
            }
        }
    }

    private void Update()
    {
        woodCost.text = towerType.woodCost.ToString();
        woodCost.color = resources.treesCount >= towerType.woodCost ? Color.white : Color.red;

        rockCost.text = towerType.rockCost.ToString();
        rockCost.color = resources.rocksCount >= towerType.rockCost ? Color.white : Color.red;
    }
}
