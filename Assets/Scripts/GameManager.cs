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
        if (IsPanelColor()) return;
        if (_currentObjectAR) _currentObjectAR.GetComponent<MeshRenderer>().enabled = false;
        _currentObjectAR = objectAR.transform.GetComponent<ObjectAR>();
        if (_currentObjectAR.GetTag() == "Static")
        {
            var staticObject = objectAR.transform.GetComponent<StaticObjectAR>();
            staticObject.SetRotationStart();
            staticObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            var dynamicObject = objectAR.transform.GetComponent<DynamicObjectAR>();
            _canvasController.SetActive(dynamicObject.GetActive());
            dynamicObject.SetRotationStart();
            dynamicObject.GetComponent<MeshRenderer>().enabled = true;   
        }
    }

    public void SetStaticObjectAR()
    {
        
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
        var objectAR = newObjectAR.GetComponent<DynamicObjectAR>();
        objectAR.SetPropertyBlock(propertyBlock);
    }

    public void RemoveObjectAR()
    {
        if (_currentObjectAR) Destroy(_currentObjectAR.gameObject);
    }

    public void CreateObjectAR(RaycastHit hitInfo)
    {
        if (IsPanelColor()) return;
        var objectAR = _canvasController.GetObjectARCreate();
        if (!objectAR) return;
        if (objectAR.CompareTag("Static"))
        {
            var distance = new Vector3(0, 0.05f, 0);
            Instantiate(objectAR, hitInfo.point + distance, Quaternion.identity);
        }
        else
        {
            var distance = new Vector3(0, 0.01f, 0);
            var newObjectAR = Instantiate(objectAR, hitInfo.point + distance, Quaternion.identity);
            ChangeColorObjectAR(newObjectAR);
        }
    }

    private bool IsPanelColor()
    {
        return _panelColor.activeSelf;
    }

    public void SetCurrentColor(Color32 color)
    {
        _currentColorObject = color;
    }

    public void ShowPanelControl()
    {
        _panelColor.SetActive(true);
    }
}
