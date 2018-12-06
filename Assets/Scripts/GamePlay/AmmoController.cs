using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    /// <summary>
    /// This class is responsible for Ammo movement in it's local forward direction and detecting collision with enemy.
    /// </summary>
    #region Public Fields	

    public float ammoSpeed = 1f; // The speed of ammo along the local Z axis.
    public float ammoLifeSpan = 2f; // Duration of time in seconds after with the ammo is disabled.
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
        // move the gameobject at forward directon at speed defined in inspector.
        transform.position += transform.forward * Time.deltaTime * ammoSpeed;
    }

    #region Public Methods	

    #endregion

    #region Private Methods	
    private void OnEnable()
    {
        CancelInvoke();

        // Call the function after certain amount of time
        Invoke("Disactivate", ammoLifeSpan);
    }

    // Making the gameobject visible and canceling the invoke to prevent furtur calling.
    private void Disactivate()
    {
        transform.gameObject.SetActive(false);
        CancelInvoke();

    }

    // Making enemy and ammo invisible when the enter trigger zone and adding score in UI by calling LevelManager class.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            LevelManager.AddScore(1);
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    #endregion


}
