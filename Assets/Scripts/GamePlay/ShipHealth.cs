using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{

    #region Public Fields
    public UnityEngine.UI.Slider shipHealthSlider;
    public int shipTotalHealth = 10;
    #endregion

    #region Private Fields	

    #endregion

    // Use this for initialization
    void Awake()
    {
        shipHealthSlider.maxValue = shipTotalHealth;
        shipHealthSlider.value = shipTotalHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Public Methods	
    public void Damage(int damageAmount)
    {
        shipHealthSlider.value -= damageAmount;
    }
    #endregion

    #region Private Methods	

    #endregion


}
