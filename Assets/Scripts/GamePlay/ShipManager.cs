using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{

    #region Public Fields	

    #endregion

    #region Private Fields	
    private ShipHealth shipHealth;
    #endregion

    // Use this for initialization
    void Start()
    {
        shipHealth = GetComponent<ShipHealth>();
         
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
            shipHealth.Damage(1);
            other.gameObject.SetActive(false);
        }            

    }
    #endregion


}
