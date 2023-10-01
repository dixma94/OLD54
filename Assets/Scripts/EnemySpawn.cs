using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] EnemyController EnemyPrefab;
    [SerializeField] GameObject pointToMove;
    [SerializeField] EnemyType enemyType;
    public float MaximumDelay;
    public float MinimumDelay;   
    public float DelayForStart;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay());

    }

    public void ChangeTypeEnemySpawn(EnemyType enemyType)
    {
        StopAllCoroutines();
        StartCoroutine(SpawnEnemyCoroutine(enemyType));
    }


    private IEnumerator SpawnEnemyCoroutine(EnemyType enemyType)
    {
        while (true)
        {
            CreateEnemy(enemyType);
            float delay = Random.Range(MinimumDelay, MaximumDelay);
            yield return new WaitForSeconds(delay);
        }

    }
    private IEnumerator Delay()
    {        

        yield return new WaitForSeconds(DelayForStart);       
        StartCoroutine(SpawnEnemyCoroutine(enemyType));
    }

    private void CreateEnemy(EnemyType enemyType)
    {
        EnemyController enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        enemy.SetDefaultPointToMove(pointToMove.transform.position);
        enemy.enemyType = enemyType;
    }
}
