using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    /// <summary>
    /// This class is responsible for instantiating ammo in a pool and displaying the cooldown time for ammo in UI
    /// This class also handles if and when user can fire the weapon.
    /// </summary>
    #region Public Fields
    public UnityEngine.UI.Slider coolDownSlider; // Slider in UI to show if user can fire the weapon.
    public float torpedoCoolTime;                // Total amount of time that takes for weapon to cool down.
    public float torpedoCoolRate;                // Rate of time in which the weapon cools down. 
    public Transform torpedoEndTranform;        // Transfrom form where the ammo is lunched.
    public ObjectPooler ammoPool;               // Generic class to instantiate array of gameobject in a pool
    public GameObject[] ammoPrefabs;            //Variations of ammos that can be created from the ObjectPooler class.
    #endregion

    #region Private Fields	

    bool isCooled = true;

    #endregion

    private void Awake()
    {
        // Creating the pool of ammos defied in inspector.
        ammoPool.instantiateObject(ammoPrefabs);

        // Defining the maximum value slider can have and setting the slider value to max at begining of level.
        coolDownSlider.maxValue = torpedoCoolTime;
        coolDownSlider.value = torpedoCoolTime;
    }
    private void Update()
    {
        // User can only fire when left mouse button is clicked and when luncher is cooled.
        if (Input.GetMouseButtonDown(0) && isCooled == true)
        {
            ammoPool.CreateObject(torpedoEndTranform.position, torpedoEndTranform.rotation);
            isCooled = false;
        }

        if (!isCooled)
            coolDownSlider.value -= torpedoCoolRate * Time.deltaTime;

        if (coolDownSlider.value <= 0)
        {
            coolDownSlider.value = torpedoCoolTime;
            isCooled = true;
        }

    }

    #region Public Methods	

    #endregion

    #region Private Methods	
    #endregion


}
