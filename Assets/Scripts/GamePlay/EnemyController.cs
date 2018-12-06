using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// This script is responsible form moving the enemy towards the perticular location
    /// This script is attached to the enemy gameobject.
    /// </summary>
    #region Public Fields	

    public float movementSpeed;
    #endregion

    #region Private Fields	

    #endregion

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move the gameobject toward the ship at speed defined in inspector.
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, movementSpeed * Time.deltaTime);
    }

    #region Public Methods	

    #endregion

    #region Private Methods	

    #endregion


}
