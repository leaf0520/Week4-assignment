using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingSystem : MonoBehaviour
{
    // List of objects to be pooled
    public List<GameObject> pooledObjects;

    // Prefab of the object to be pooled
    public GameObject objectToPool;

    // Maximum number of objects to be pooled
    public int maxPooledObjects;

    // List of pooled objects
    private List<GameObject> pooledObjectList;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Initialize the list of pooled objects
        pooledObjectList = new List<GameObject>();

        // Create the objects and add them to the list
        for (int i = 0; i < maxPooledObjects; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjectList.Add(obj);
        }
    }

    // GetPooledObject is called to get a pooled object
    public GameObject GetPooledObject()
    {
        // Go through the list of pooled objects
        for (int i = 0; i < pooledObjectList.Count; i++)
        {
            // Check if the object is not active
            if (!pooledObjectList[i].activeInHierarchy)
            {
                // Return the object
                return pooledObjectList[i];
            }
        }

        // If no object is found, create a new one
        GameObject obj = (GameObject)Instantiate(objectToPool);
        obj.SetActive(false);
        pooledObjectList.Add(obj);
        return obj;
    }
}