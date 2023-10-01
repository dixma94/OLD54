using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour
{
    public float targetWaterHeight = 0;
    public float riseWaterSpeed = 4;
    public WaterLevel[] waterLevels;
    public float nextLevelTime = 0;
    private int waterLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartRising();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRising()
    {
        targetWaterHeight = transform.position.y;
        ApplyWaterLevel(waterLevels[0]);
    }

    public void ApplyWaterLevel(WaterLevel level)
    {
        targetWaterHeight = level.y;
        StartCoroutine(nameof(WaitForNextWaterLevel), level.duration);
    }

    public IEnumerator WaitForNextWaterLevel(float time)
    {
        nextLevelTime = time;
        while(nextLevelTime > 0)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, targetWaterHeight, riseWaterSpeed * Time.deltaTime), transform.position.z);
            nextLevelTime -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        waterLevel++;
        ApplyWaterLevel(waterLevels[waterLevel]);
    }
}

[System.Serializable]
public class WaterLevel
{
    public float y;
    public float duration;
}
