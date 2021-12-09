using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputMouse : MonoBehaviour
{
    private GameManager _gameManager;
    private float _touchDistance;
    private Vector2 _touchStart, _touchEnd;

    private void Awake()
    {
        _gameManager = GetComponent<GameManager>();
    }
    
    private void Update()
    {
#if UNITY_EDITOR
        GetInput();
#endif
    }

    private void GetInput()
    {
        if (Camera.main != null && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, float.MaxValue))
                {
                    if (hit.transform.gameObject.CompareTag("Terrain"))
                    {
                        _gameManager.SetNullObjectAR();
                        _gameManager.CreateObjectAR(hit);   
                    }
                    else
                    {
                        Debug.Log(hit.collider.name);
                        _gameManager.SetObjectAR(hit);
                        _touchStart = Input.mousePosition;   
                    }
                } else
                    _gameManager.SetNullObjectAR();
                return;
            }
            
            if (Input.GetMouseButton(0))
            {
                if (_gameManager.GetObjectAR())
                {
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out var hit, float.MaxValue))
                    {
                        _gameManager.GetObjectAR().TouchOnObjectAR(hit);   
                    }
                    _touchEnd = Input.mousePosition;
                    _gameManager.GetObjectAR().TouchOnObjectAR(_touchEnd.magnitude - _touchStart.magnitude);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                //_gameManager.SetNullObjectAR();
            }
        }
    } 
}
