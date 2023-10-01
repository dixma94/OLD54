using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "ScriptableObjects/Data/Tower", order = 1)]

public class TowerData : ScriptableObject
{
    public int id;
    public int woodCost;
    public int rockCost;

    public TowerController prefab;
}
