using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{

    #region Public Fields	

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

    }

    #region Public Methods	

    #endregion

    #region Private Methods	
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            LevelManager.DoDamage(1);
            other.gameObject.SetActive(false);
        }

    }
    #endregion


}
