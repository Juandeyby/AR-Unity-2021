using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAR : MonoBehaviour
{
    [SerializeField] private Transform _child;
    private GameManager _gameManager;
    private CanvasController _canvasController;
    private Rigidbody _rigidbody;
    private Vector3 _rotationStart;
    private Vector3 _scaleStart;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _gameManager = FindObjectOfType<GameManager>();
        _canvasController = FindObjectOfType<CanvasController>();
    }

    private void Update()
    {
        _rigidbody.velocity = Vector3.zero;
        CheckDestroy();
    }

    private void CheckDestroy()
    {
        if (transform.position.y <= -0.5f)
        {
            _gameManager.PlayClip("delete");
            Destroy(gameObject);
        }
    }

    public void SetActive(bool active)
    {
        _rigidbody.isKinematic = active;
    }

    public bool GetActive()
    {
        return _rigidbody.isKinematic;
    }

    public void SetRotationStart()
    {
        _rotationStart = transform.rotation.eulerAngles;
        _scaleStart = transform.localScale;
    }
    
    public void TouchOnObjectAR(RaycastHit hit) 
    {
        if (_rigidbody.isKinematic) return;
        if (_canvasController.GetTransformId() == 0) PositionObjectAR(hit); // Size
    }
    
    public void TouchOnObjectAR(float touchMagnitude)
    {
        if (_rigidbody.isKinematic) return;
        if (_canvasController.GetTransformId() == 1) RotateObjectAR(touchMagnitude); //Rotate
        if (_canvasController.GetTransformId() == 2) ScaleObjectAR(touchMagnitude); //Scale
    }

    private void PositionObjectAR(RaycastHit hit)
    {
        switch (_gameManager.GetCurrentAxis())
        {
            case 0: // X
                transform.position = new Vector3(hit.point.x, transform.position.y, transform.position.z);       
                break;
            case 1: // Y
                transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
                break;
            case 2: // Z
                transform.position = new Vector3(transform.position.x, transform.position.y, hit.point.z);
                break;
        }
    }
    
    private void RotateObjectAR(float touchMagnitude)
    {
        transform.rotation = Quaternion.Euler(_rotationStart);
        switch (_gameManager.GetCurrentAxis())
        {
            case 0: // X
                transform.Rotate(touchMagnitude, 0, 0);
                break;
            case 1: // Y
                transform.Rotate(0, touchMagnitude, 0);  
                break;
            case 2: // Z
                transform.Rotate(0, 0, touchMagnitude);
                break;
        }
    }
    
    private void ScaleObjectAR(float touchMagnitude)
    {
        transform.localScale = _scaleStart;
        var newMagnitude = touchMagnitude * 0.001f;
        switch (_gameManager.GetCurrentAxis())
        {
            case 0: // X
                if (newMagnitude + transform.localScale.x < 0.01f)
                {
                    transform.localScale = new Vector3(0.01f, transform.localScale.y, transform.localScale.z);
                    return;
                }
                transform.localScale = new Vector3(
                    newMagnitude + transform.localScale.x, transform.localScale.y, transform.localScale.z);
                break;
            case 1: // Y
                if (newMagnitude + transform.localScale.y < 0.01f)
                {
                    transform.localScale = new Vector3(transform.localScale.x, 0.01f, transform.localScale.z);
                    return;
                }
                transform.localScale = new Vector3(
                    transform.localScale.x, newMagnitude + transform.localScale.y, transform.localScale.z);  
                break;
            case 2: // Z
                if (newMagnitude + transform.localScale.z < 0.01f)
                {
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0.01f);
                    return;
                }
                transform.localScale = new Vector3(
                    transform.localScale.x, transform.localScale.y, newMagnitude + transform.localScale.z);
                break;
        }
    }

    public void SetPropertyBlock(MaterialPropertyBlock newPropertyBlock)
    {
        var renderer = _child.GetComponent<Renderer>();
        if (renderer)
        {
            renderer.SetPropertyBlock(newPropertyBlock);
        }
    }
}
