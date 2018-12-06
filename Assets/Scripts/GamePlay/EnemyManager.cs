using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    /// <summary>
    /// This class is responisble for instantiating and displaying different kind of enemies after some interval of time
    /// and randomizing the enemy position within 3D space.
    /// </summary>
    #region Public Fields	
    public ObjectPooler enemyPool; // Generic class to instantiate array of gameobject in a pool
    public float enemySpawnTime;   // Duration of time in seconds after with the new enemy is displayed.
    [Range(0, 25)]
    public float minSpawnDistance;
    [Range(26, 50)]
    public float maxSpawnDistance;
    public GameObject[] enemyPrefabs; // Variations of enemy that can be created from the ObjectPooler class.
    #endregion

    #region Private Fields	

    private float timeSinceEnemyCreated = 0f;
    private float orthographicCameraSize = 0f;
    private Vector2 enemySpawnRadius;
    #endregion

    // Use this for initialization
    void Awake()
    {
        // creating different kinds of enemy and putting them in pool so they can be retrived later.
        enemyPool.instantiateObject(enemyPrefabs);
    }

    // Update is called once per frame
    void Update()
    {
        // Check so that enemy are not created each frame.
        timeSinceEnemyCreated += Time.deltaTime;

        // creating enemy after user defined time.
        if (timeSinceEnemyCreated >= enemySpawnTime)
        {
            // Positioning the enemy between random minimum and maximum distance.
            Vector3 enemyPosition = new Vector3(Random.Range(minSpawnDistance, maxSpawnDistance) * randomPlusMinus(), 0f, Random.Range(minSpawnDistance, maxSpawnDistance) * randomPlusMinus());
            enemyPool.CreateObject(enemyPosition, Quaternion.identity);
            timeSinceEnemyCreated = 0f;
        }
    }

    #region Public Methods	

    #endregion

    #region Private Methods
    // Function to return the random +1 or -1 so that enemies can be generated from all directions.
    private int randomPlusMinus()
    {
        if (Random.Range(0, 2) == 0)
            return -1;
        else
            return 1;
    }
    #endregion


}
