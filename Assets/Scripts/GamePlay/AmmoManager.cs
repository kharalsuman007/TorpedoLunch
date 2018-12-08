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
    public Transform torpedoVisualLuancher;     // Visual display of torpedoLuncher to face the direction where mouse was previously clicked
    public ObjectPooler ammoPool;               // Generic class to instantiate array of gameobject in a pool
    public GameObject[] ammoPrefabs;            //Variations of ammos that can be created from the ObjectPooler class.
    #endregion

    #region Private Fields	
    private List<Quaternion> torpedoQuaternions = new List<Quaternion>();   // List of quaternions to save the rotation of invisible torpedo towards mouse direction
    private List<Vector3> torpedoTipPositions = new List<Vector3>();        // List of positions of the tip of invisible torpedo.
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

        if (Input.GetMouseButtonDown(0))
        {
            // Adding the last rotation of invisible torpedo and position of invisible torpedo end towards the mouse position when clicked
            torpedoQuaternions.Add(torpedoEndTranform.rotation);
            torpedoTipPositions.Add(torpedoEndTranform.position);
        }

        // Firing the ammo only when the torpedo has cooled down
        if (isCooled)
        {
            // Checking if the user has previouse clicked the left mouse button.
            if (!(torpedoQuaternions.Count <= 0))
            {
                // Getting the rotation and position of torpedo from the first elements of lists of quaternion and position
                Quaternion torpedoQuaternion = torpedoQuaternions[0];
                Vector3 torpedoTipPosition = torpedoTipPositions[0];

                // Removing the rotation and position of torpedo from the first elements of lists as they are already stored.
                torpedoQuaternions.RemoveAt(0);
                torpedoTipPositions.RemoveAt(0);

                // Creating object pool from the temporarily saved quaternion and position.
                ammoPool.CreateObject(torpedoTipPosition, torpedoQuaternion);

                // Setting the visual torpedo luncher direction and position to mimic facing the last clicked direction of mouse.
                torpedoVisualLuancher.rotation = torpedoQuaternion;
                isCooled = false;
            }
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
