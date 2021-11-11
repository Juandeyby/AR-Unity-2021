using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class ObjectCreated : MonoBehaviour
{
    private GameObject _axisXYZ;
    private GameManager _gameManager;

    public void SetAxisXYZ(GameObject newAxis)
    {
        _axisXYZ = newAxis;
    }

    public GameObject GetAxisXYZ()
    {
        return _axisXYZ;
    }
    
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void OnMouseDown()
    {
        _gameManager.currentObject = gameObject.name;
        var listObjectsCreated = FindObjectsOfType<ObjectCreated>();
        foreach (var ObjectCreated in listObjectsCreated)
        {
            ObjectCreated.GetAxisXYZ().SetActive(false);
        }
        _axisXYZ.SetActive(true);
    }
}
