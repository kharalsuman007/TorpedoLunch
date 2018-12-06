using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCursor : MonoBehaviour
{
    /// <summary>
    /// This script is responsible for making the gameobject face the direction of mouse cursor.
    /// </summary>
    #region Public Fields	

    #endregion

    #region Private Fields	
    private Vector3 mouseWorldPosition; // Vector3 to convert the mouse position into world point
    private float cameraDifference;     // Difference between camera and target object in Y-axis
    #endregion

    // Use this for initialization
    void Start()
    {
        cameraDifference = Camera.main.transform.position.y - transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Converting the mouse positon to world axis position
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDifference));

        // Setting and looking target direction by the gameobject this script is attached to
        Vector3 topedoLookDirection = new Vector3(mouseWorldPosition.x, transform.position.y, mouseWorldPosition.z);
        transform.LookAt(topedoLookDirection);

        /*
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        mouseWorldPosition = new Vector3(mouseWorldPosition.x, transform.position.y, mouseWorldPosition.z);
        Vector3 direction = mouseWorldPosition - transform.position;
        transform.localRotation = Quaternion.LookRotation(direction, Vector3.up);
        */

    }

    #region Public Methods	

    #endregion

    #region Private Methods	

    #endregion


}
