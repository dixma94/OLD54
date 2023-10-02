using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPreview : MonoBehaviour
{
    private int currentTower = 0;

    public ResourcesUI resources;
    public GameObject[] towerPreviews;

    // Update is called once per frame
    void Update()
    {
        if (resources.towerToBuild != currentTower)
        {
            currentTower = resources.towerToBuild;

            for(int i = 0; i < towerPreviews.Length; i++)
            {
                towerPreviews[i].SetActive(i == currentTower - 1);
            }
        }
    }
}
