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

    public void Create(GameObject objectPrefab)
    {
        var objectCreated = Instantiate(objectPrefab);
        objectCreated.name = objectPrefab.name + order;
        order++;
        // var axisCreated = Instantiate(axisPrefab);
        //
        // axisCreated.transform.parent = objectCreated.transform;
        // axisCreated.transform.localPosition = Vector3.zero;
        //
        // objectCreated.GetComponentInChildren<ObjectCreated>().SetAxisXYZ(axisCreated);
        // foreach (Transform trans in axisCreated.transform)
        // {
        //     var objectChild = objectCreated.transform.GetChild(0).gameObject;
        //     trans.GetComponent<Axis>().SetObjectTarget(objectChild);
        // }
        // objectCreated.transform.eulerAngles = new Vector3(0, 180f, 0);
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
