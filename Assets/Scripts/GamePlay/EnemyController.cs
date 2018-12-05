using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

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
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, movementSpeed * Time.deltaTime);
    }

    #region Public Methods	

    #endregion

    #region Private Methods	

    #endregion


}
