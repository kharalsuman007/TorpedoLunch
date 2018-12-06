using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    #region Public Fields	
    public ObjectPooler enemyPool;
    public float enemySpawnTime;
    public GameObject[] enemyPrefabs;
    #endregion

    #region Private Fields	

    private float timeSinceEnemyCreated = 0f;
    private float orthographicCameraSize = 0f;
    private Vector2 enemySpawnRadius;
    #endregion

    // Use this for initialization
    void Awake()
    {
        enemyPool.instantiateObject(enemyPrefabs);
        orthographicCameraSize = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceEnemyCreated += Time.deltaTime;

        if (timeSinceEnemyCreated >= enemySpawnTime)
        {
            Vector3 enemyPosition = new Vector3(Random.Range(orthographicCameraSize / 2, orthographicCameraSize) * randomPlusMinus(), 0f, Random.Range(orthographicCameraSize / 2, orthographicCameraSize) * randomPlusMinus());
            enemyPool.CreateObject(enemyPosition, Quaternion.identity);
            timeSinceEnemyCreated = 0f;
        }
    }

    #region Public Methods	

    #endregion

    #region Private Methods	
    private int randomPlusMinus()
    {
        if (Random.Range(0, 2) == 0)
            return -1;
        else
            return 1;
    }
    #endregion


}
