using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    #region Public Fields

    public GameObject poolObject;
    public int pollSize = 15;


    #endregion

    #region Private Fields	

    private GameObject[] poolObjectArray;
    private Queue<Transform> objectQueue = new Queue<Transform>();

    #endregion

    // Use this for initialization
    void Start()
    {
        poolObjectArray = new GameObject[pollSize];

        for (int i = 0; i < poolObjectArray.Length; i++)
        {
            poolObjectArray[i] = Instantiate(poolObject, Vector3.zero, Quaternion.identity) as GameObject;
            poolObjectArray[i].name = "GameObject" + i.ToString();
            Transform objTransform = poolObjectArray[i].GetComponent<Transform>();
            objTransform.SetParent(transform);
            objectQueue.Enqueue(objTransform);
            objTransform.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Public Methods	

    public void CreateObject(Vector3 _position, Quaternion _rotation)
    {
        Transform spawnedObject = objectQueue.Dequeue();
        spawnedObject.position = _position;
        spawnedObject.rotation = _rotation;
        spawnedObject.gameObject.SetActive(true);
        objectQueue.Enqueue(spawnedObject);
    }

    #endregion

    #region Private Methods	



    #endregion


}
