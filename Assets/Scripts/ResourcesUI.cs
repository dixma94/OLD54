using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TreeText;
    [SerializeField] private TextMeshProUGUI RockText;

    public int treesCount;
    public int rocksCount;
    public bool HaveTowerToBuild = false;
    private void Start()
    {
        UpdateText();
        EntityManager.Instance.TargetKilled += Instance_TargetKilled;
    }

    private void Instance_TargetKilled(Targettable targettable)
    {
        switch (targettable.targetType)
        {
            case EntityType.Enemy:
                break;
            case EntityType.Tower:
                break;
            case EntityType.Hero:
                break;
            case EntityType.Trees:
                treesCount++;
                break;
            case EntityType.Rocks: 
                rocksCount++;
                break;
            default:
                break;
        }
        UpdateText();
    }
    public void UpdateText()
    {
        TreeText.text = treesCount.ToString();
        RockText.text = rocksCount.ToString();
    }
}
