using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{

    #region Public Fields
    public UnityEngine.UI.Slider coolDownSlider;
    public float torpedoCoolTime;
    public float torpedoCoolRate;
    public Transform torpedoEndTranform;
    public ObjectPooler ammoPool;
    public GameObject[] ammoPrefabs;
    #endregion

    #region Private Fields	

    bool isCooled = true;

    #endregion

    private void Awake()
    {
        ammoPool.instantiateObject(ammoPrefabs);
        coolDownSlider.maxValue = torpedoCoolTime;
        coolDownSlider.value = torpedoCoolTime;
    }
    private void Update()
    {
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
