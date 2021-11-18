using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class ObjectCreated : MonoBehaviour
{
    [SerializeField] private Transform axis;
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
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(raycast, out var hit))
        {
            if (hit.transform.parent.name == transform.parent.name)
            {
                _canvasController.objectSelected.text = gameObject.transform.parent.name; 
                _gameManager.currentObject = gameObject.transform.parent.name;
                var listObjectsCreated = FindObjectsOfType<PrefabCreated>();
                foreach (var prefabCreated in listObjectsCreated)
                {
                    if (prefabCreated.name == transform.parent.name)
                    {
                        GetComponent<Rigidbody>().isKinematic = true;
                        foreach (Transform child in axis)
                        {
                            
                            child.gameObject.SetActive(true);
                        }
                    }
                    else
                    {
                        prefabCreated.transform.GetChild(1).GetComponent<Rigidbody>().isKinematic = false;
                        foreach (Transform child in prefabCreated.transform.GetChild(2))
                        {
                            child.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
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
                Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(raycast, out var hit))
                {
                    if (hit.transform.parent.name == transform.parent.name)
                    {
                        _canvasController.objectSelected.text = gameObject.transform.parent.name; 
                        _gameManager.currentObject = gameObject.transform.parent.name;
                        var listObjectsCreated = FindObjectsOfType<PrefabCreated>();
                        foreach (var prefabCreated in listObjectsCreated)
                        {
                            if (prefabCreated.name == transform.parent.name)
                            {
                                foreach (Transform child in transform)
                                {
                                    child.gameObject.SetActive(true);
                                }
                            }
                            else
                            {
                                foreach (Transform child in prefabCreated.transform.GetChild(1))
                                {
                                    child.gameObject.SetActive(false);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
#endif
}
