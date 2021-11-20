using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputTouch : MonoBehaviour
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
#if UNITY_ANDROID
        GetInput();
#endif
    }
    
    private void GetInput()
    {
        if (Camera.main != null)
        {
            if (Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    if (Physics.Raycast(ray, out var hit, float.MaxValue))
                    {
                        Debug.Log(hit.collider.name);
                        _gameManager.SetObjectAR(hit);
                        _touchStart = Input.GetTouch(0).position;
                    } else
                        _gameManager.SetNullObjectAR();
                }
                
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    if (Physics.Raycast(ray, out var hit, float.MaxValue))
                    {
                        _gameManager.GetObjectAR().TouchOnObjectAR(hit);
                    }
                    _touchEnd = Input.GetTouch(0).position;
                    _gameManager.GetObjectAR().TouchOnObjectAR(_touchEnd.magnitude - _touchStart.magnitude);
                }
                
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    //_gameManager.SetNullObjectAR();
                }
            }
        }
    } 
}
