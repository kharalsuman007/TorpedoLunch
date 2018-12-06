using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    /// <summary>
    /// This class is responsible for instatiating defined number of gameobjects and setting their parent to the gameobject to which this script is attached.
    /// Furthermore it also pools the object from the queue and shows them to give a impression that the gameobjects are created and destroyed.
    /// </summary>
    #region Public Fields

    public int pollSize = 15; // Number of gameobjects to be created in a pool

    #endregion

    #region Private Fields	

    private GameObject[] poolObjectArray;       // Array to store the gameobjects created as defined in pollSize.
    private Queue<Transform> objectQueue = new Queue<Transform>(); //Reference to the transfrom of gameobjects created from pool.

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


    public void instantiateObject(GameObject[] poolObject)
    {
        // creating the array of gameobject defined in inspector
        poolObjectArray = new GameObject[pollSize];

        // iterating and instantiating gameobjects defined in inspector.
        for (int i = 0; i < poolObjectArray.Length; i++)
        {
            poolObjectArray[i] = Instantiate(poolObject[Random.Range(0, poolObject.Length)], Vector3.zero, Quaternion.identity) as GameObject;
            Transform objTransform = poolObjectArray[i].GetComponent<Transform>();
            objTransform.SetParent(transform);
            objectQueue.Enqueue(objTransform);
            objTransform.gameObject.SetActive(false);
        }

    }

    // making the gameobject visible in the queue and setting their position and rotation recived as parameters.
    public void CreateObject(Vector3 _position, Quaternion _rotation)
    {
        // Getting the reference to the transform in the queue , the transform is no longer in the queue.
        Transform spawnedObject = objectQueue.Dequeue();
        spawnedObject.position = _position;
        spawnedObject.rotation = _rotation;
        spawnedObject.gameObject.SetActive(true);

        // putting the transfrom back to the queue
        objectQueue.Enqueue(spawnedObject);
    }

    #endregion

    #region Private Methods	



    #endregion


}
