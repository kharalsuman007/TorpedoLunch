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
    private float maxDistanceInsideScreen = 0f;
    private Vector2 enemySpawnRadius;
    #endregion

    // Use this for initialization
    void Awake()
    {
        // creating different kinds of enemy and putting them in pool so they can be retrived later.
        enemyPool.instantiateObject(enemyPrefabs);
        maxDistanceInsideScreen = Mathf.Sqrt((Screen.width / 2) ^ 2 + (Screen.height / 2) ^ 2); // Pythagoras theorem.
    }

    // Update is called once per frame
    void Update()
    {
        // Check so that enemy are not created each frame.
        timeSinceEnemyCreated += Time.deltaTime;

        // creating enemy after user defined time.
        if (timeSinceEnemyCreated >= enemySpawnTime)
        {
            // Random value within a complete circle in radians (would be 0 - 360 in degrees)
            float spawnAngle = Random.Range(0, 2 * Mathf.PI); 

            // Equation of the circle
            Vector3 enemyPosition = new Vector3(maxDistanceInsideScreen * Mathf.Cos(spawnAngle), 0f, maxDistanceInsideScreen * Mathf.Sin(spawnAngle));
            
            enemyPool.CreateObject(enemyPosition, Quaternion.identity);
            timeSinceEnemyCreated = 0f;
        }

    }

    #region Public Methods	

    #endregion

    #region Private Methods

    #endregion


}
