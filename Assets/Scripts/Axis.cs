using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{
    [SerializeField] private Transform _ObjectTarget;
    private GameManager _gameManager;
    private float distance;
    private Vector2 startPos;
    private Vector2 endPos;
    private GameObject axis;
    
    // float movedownY = 0.0f;
    // float sensitivityY = 1;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        // movedownY += Input.GetAxis("Mouse Y") * sensitivityY;
        // if (Input.GetAxis("Mouse Y") != 0){
        //     transform.parent.Translate(Vector3.forward * movedownY);
        // }
        // movedownY = 0.0f;
        //
        
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
        
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                startPos = Input.mousePosition;
                axis = hit.transform.gameObject;
            }
        }

        if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            distance = endPos.x - startPos.x;
            //distance = Vector2.Distance(endPos, startPos);

            switch (_gameManager.tranformMode)
            {
                case "position":
                    PositionAxis();
                    break;
                case "rotation":
                    RotationAxis();
                    break;
                case "scale":
                    ScaleAxis();
                    break;
            }
            
        }

        // if (Input.GetMouseButtonUp(0))
        // {
        //     endPos = Input.mousePosition;
        //     distance = Vector2.Distance(endPos, startPos);
        //     if (axis.name == "AxisX")
        //     {
        //         transform.parent.localPosition += new Vector3(distance * 0.001f, 0, 0);
        //     }
        // }
        
        // if (Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);
        //
        //     if (touch.phase == TouchPhase.Began)
        //     {
        //         Ray ray = Camera.main.ScreenPointToRay(touch.position);
        //     }
        // }
    }

    private void PositionAxis()
    {
        switch (axis.name)
        {
            case "AxisX":
                _ObjectTarget.Translate(distance * 0.00005f, 0, 0);
                break;
            case "AxisY":
                _ObjectTarget.Translate(0, distance * 0.00005f, 0);
                break;
            case "AxisZ":
                _ObjectTarget.Translate(0, 0, distance * 0.00005f);
                break;
        }
    }
    
    private void ScaleAxis()
    {
        switch (axis.name)
        {
            case "AxisX":
                _ObjectTarget.localScale += new Vector3(distance * 0.00005f, 0, 0);
                break;
            case "AxisY":
                _ObjectTarget.localScale += new Vector3(0, distance * 0.00005f, 0);
                break;
            case "AxisZ":
                _ObjectTarget.localScale += new Vector3(0, 0, distance * 0.00005f);
                break;
        }
        ResetScaleAxis();
    }

    public void ResetScaleAxis()
    {
        if (transform.gameObject.name == "AxisX")
        {
            transform.localScale = new Vector3(1 / _ObjectTarget.localScale.x * 0.5f,1 / _ObjectTarget.localScale.y * 0.1f,1 / _ObjectTarget.localScale.z * 0.1f);                    
        } else if (transform.gameObject.name == "AxisY")
        {
            transform.localScale = new Vector3(1 / _ObjectTarget.localScale.x * 0.1f,1 / _ObjectTarget.localScale.y * 0.5f,1 / _ObjectTarget.localScale.z * 0.1f);   
        } else if (transform.gameObject.name == "AxisZ")
        {
            transform.localScale = new Vector3(1 / _ObjectTarget.localScale.x * 0.1f,1 / _ObjectTarget.localScale.y * 0.1f,1 / _ObjectTarget.localScale.z * 0.5f);
        }
    }
    
    private void RotationAxis()
    {
        switch (axis.name)
        {
            case "AxisX":
                _ObjectTarget.Rotate(distance * 0.00005f, 0, 0);
                break;
            case "AxisY":
                _ObjectTarget.Rotate(0, distance * 0.00005f, 0);
                break;
            case "AxisZ":
                _ObjectTarget.Rotate(0, 0, distance * 0.00005f);
                break;
        }
    }
}
