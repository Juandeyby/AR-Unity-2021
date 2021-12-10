using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _panelColor;
    private CanvasController _canvasController;

    private AudioController _audioController;
    
    private ObjectAR _currentObjectAR;
    private Color32 _currentColorObject;
    private Vector3 _currentSizeObject;
    
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
        if (_canvasController.isCreating())
        {
            CreateObjectAR(objectAR);
        }
        else
        {
            if (IsPanelColor()) return;
            if (_currentObjectAR) _currentObjectAR.GetComponent<MeshRenderer>().enabled = false;
            _currentObjectAR = objectAR.transform.GetComponent<ObjectAR>();
            _canvasController.SetActive(_currentObjectAR.GetActive());
            _currentObjectAR.SetRotationStart();
            _currentObjectAR.GetComponent<MeshRenderer>().enabled = true;  
        }
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

    private void ChangeColorObjectAR(GameObject newObjectAR)
    {
        var propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetColor("_Color", _currentColorObject);
        var objectAR = newObjectAR.GetComponent<ObjectAR>();
        objectAR.SetPropertyBlock(propertyBlock);
    }

    public void RemoveObjectAR()
    {
        if (_currentObjectAR) Destroy(_currentObjectAR.gameObject);
    }

    public void CreateObjectAR(RaycastHit hitInfo)
    {
        if (IsPanelColor()) return;
        var objectPrefabAR = _canvasController.GetObjectARCreate();
        if (!objectPrefabAR) return;
        var distance = new Vector3(0, 0.05f * _currentSizeObject.y, 0);
        var newObjectAR = Instantiate(objectPrefabAR, hitInfo.point + distance, Quaternion.identity);
        newObjectAR.transform.localScale = _currentSizeObject * 5f;
        ChangeColorObjectAR(newObjectAR);
        _canvasController.SetEmptyObjectPrefabAR();
    }

    private bool IsPanelColor()
    {
        return _panelColor.activeSelf;
    }

    public void SetCurrentColor(Color32 newColor)
    {
        _currentColorObject = newColor;
    }

    public void SetCurrentSize(Vector3 newSize)
    {
        _currentSizeObject = newSize;
    }

    public void ShowPanelControl()
    {
        _panelColor.SetActive(true);
    }
}
