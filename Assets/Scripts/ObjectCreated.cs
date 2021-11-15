using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class ObjectCreated : MonoBehaviour
{
    private GameManager _gameManager;
    private CanvasController _canvasController;

    private void Start()
    {
        _canvasController = FindObjectOfType<CanvasController>();
        _gameManager = FindObjectOfType<GameManager>();
    }

#if UNITY_EDITOR
    private void OnMouseDown()
    {
        _canvasController.objectSelected.text = gameObject.transform.parent.name;
        _gameManager.currentObject = gameObject.transform.parent.name;
        var listObjectsCreated = FindObjectsOfType<PrefabCreated>();
        foreach (var prefabCreated in listObjectsCreated)
        {
            prefabCreated.GetBox().gameObject.SetActive(false);
        }
        gameObject.SetActive(true);
    }
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
        
            if (touch.phase == TouchPhase.Began)
            {
                _canvasController.objectSelected.text = gameObject.transform.parent.name; 
                _gameManager.currentObject = gameObject.transform.parent.name;
                var listObjectsCreated = FindObjectsOfType<PrefabCreated>();
                foreach (var prefabCreated in listObjectsCreated)
                {
                    prefabCreated.GetBox().gameObject.SetActive(false);
                }
                gameObject.SetActive(true);
            }
        }
    }
#endif
}
