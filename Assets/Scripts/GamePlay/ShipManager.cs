using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    /// <summary>
    /// This script is responsible for detecting the collison of enemy to the spaceship
    /// Furthermore it informs level manager to decrese the player health. 
    /// </summary>
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
    //If the gameobject ship collides with is tagged as enemy the health is decreased by calling LevelManager script
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
