using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{

    #region Public Fields	

    public float ammoSpeed = 1f;
    public float ammoLifeSpan = 2f;
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
        transform.position += transform.forward * Time.deltaTime * ammoSpeed;
    }

    #region Public Methods	

    #endregion

    #region Private Methods	
    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Disactivate", ammoLifeSpan);
    }

    private void Disactivate()
    {
        transform.gameObject.SetActive(false);
        CancelInvoke();

    }

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
