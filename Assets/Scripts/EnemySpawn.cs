using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] EnemyController EnemyPrefab;
    [SerializeField] GameObject pointToMove;
    [SerializeField] EnemyType enemyType;
    public float SpawnDelay;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(SpawnEnemyCoroutine(enemyType));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChannelTypeEnemySpawn(EnemyType enemyType)
    {
        StopAllCoroutines();
        StartCoroutine(SpawnEnemyCoroutine(enemyType));
    }


    private IEnumerator SpawnEnemyCoroutine(EnemyType enemyType)
    {
        while (true)
        {
            CreateEnemy(enemyType);
            yield return new WaitForSeconds(SpawnDelay);
        }

    }

    private void CreateEnemy(EnemyType enemyType)
    {
        EnemyController enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        enemy.SetDefaultPointToMove(pointToMove.transform.position);
        enemy.enemyType = enemyType;
    }
}
