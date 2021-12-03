using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CanvasController _canvasController;
    private AudioController _audioController;
    private ObjectAR _currentObjectAR;
    private int _currentXYZ;

    private void Awake()
    {
        _canvasController = FindObjectOfType<CanvasController>();
        _audioController = GetComponent<AudioController>();
    }

    public ObjectAR GetObjectAR()
    {
        return _currentObjectAR;
    }

    public void PlayClip(string key)
    {
        _audioController.Play(key);
    }
    
    public void SetObjectAR(RaycastHit objectAR)
    {
        if (_currentObjectAR) _currentObjectAR.GetComponent<MeshRenderer>().enabled = false;
        _currentObjectAR = objectAR.transform.GetComponent<ObjectAR>();
        _canvasController.SetActive(_currentObjectAR.GetActive());
        _currentObjectAR.SetRotationStart();
        _currentObjectAR.GetComponent<MeshRenderer>().enabled = true;
    }

    public void SetNullObjectAR()
    {
        if (_currentObjectAR) _currentObjectAR.GetComponent<MeshRenderer>().enabled = false;
        _currentObjectAR = null;
    }

    public int GetCurrentAxis()
    {
        return _currentXYZ;
    }

    public void SetCurrentAxis(int value)
    {
        _currentXYZ = value;
    }

    private void ChangeColorObjectAR(Color color)
    {
        var propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetColor("_Color", color);
        var renderer = _currentObjectAR.GetComponent<Renderer>();
        renderer.SetPropertyBlock(propertyBlock);
    }

    public void RemoveObjectAR()
    {
        if (_currentObjectAR) Destroy(_currentObjectAR.gameObject);
    }

    public void CreateObjectAR(RaycastHit hitInfo)
    {
        var objectAR = _canvasController.GetObjectARCreate();
        if (objectAR)
        {
            var distance = new Vector3(0, 0.01f, 0);
            Instantiate(objectAR, hitInfo.point + distance, Quaternion.identity);   
        }
    }
}
