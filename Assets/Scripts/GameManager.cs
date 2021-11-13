using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string tranformMode;
    public GameObject axisPrefab;
    public string currentObject;
    private int order = 0;
    
    public void SetModeTransform(string mode)
    {
        tranformMode = mode;
    }

    public void NewObjectCreated(GameObject objectPrefab)
    {
        var objectCreated = Instantiate(objectPrefab, Vector3.zero, Quaternion.identity);
        objectCreated.name = objectPrefab.name + order;
        order++;
        var axisCreated = Instantiate(axisPrefab);
        
        axisCreated.transform.parent = objectCreated.transform.GetChild(0);
        axisCreated.transform.localPosition = Vector3.zero;
        
        objectCreated.GetComponentInChildren<ObjectCreated>().SetAxisXYZ(axisCreated);
        foreach (Transform trans in axisCreated.transform)
        {
            trans.GetComponent<Axis>().SetObjectTarget(objectCreated.transform.GetChild(0).gameObject);
        }
    }

    public void RemoveObjectOnClick()
    {
        if (GameObject.Find(currentObject))
        {
            var temp = GameObject.Find(currentObject);
            Destroy(temp);   
        }
    }
}
