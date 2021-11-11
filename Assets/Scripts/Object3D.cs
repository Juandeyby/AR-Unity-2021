using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object3D : MonoBehaviour
{
    public GameObject ObjectPrefab;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void NewObjectOnClick()
    {
        _gameManager.NewObjectCreated(ObjectPrefab);
    }
}
