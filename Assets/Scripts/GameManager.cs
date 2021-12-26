using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string DATABASE_URL_APP = "https://testing-lidyi-default-rtdb.firebaseio.com/";
    
    [SerializeField] private GameObject _panelColor;
    [SerializeField] private Transform _objectsARParent;
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
    
    public void SetObjectAR(RaycastHit hitInfo)
    {
        if (_canvasController.isCreating())
        {
            CreateObjectAR(hitInfo);
        }
        else
        {
            if (IsPanelColor()) return;
            _canvasController.SetTransformPanel(true);
            if (_currentObjectAR) _currentObjectAR.GetComponent<MeshRenderer>().enabled = false;
            _currentObjectAR = hitInfo.transform.GetComponent<ObjectAR>();
            _canvasController.SetActive(_currentObjectAR.GetActive());
            _currentObjectAR.SetRotationStart();
            _currentObjectAR.GetComponent<MeshRenderer>().enabled = true;  
        }
    }

    public void SetNullObjectAR()
    {
        _canvasController.SetTransformPanel(false);
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
        var distance = new Vector3(0, 0.005f * _currentSizeObject.y, 0);
        var newObjectAR = Instantiate(
            objectPrefabAR,
            ObjectAR.SnapPosition(hitInfo.point) + distance,
            Quaternion.identity
            );
        newObjectAR.transform.parent = _objectsARParent;
        newObjectAR.transform.localScale = _currentSizeObject / 2f;
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

    public void SaveEnvironment(string environmentId)
    {
        foreach (Transform objectAR in _objectsARParent)
        {
            var objectData = new ObjectARData(objectAR.GetComponent<ObjectAR>());

            var dbController = new DBController();
            dbController.OnComplete = (onResolved) =>
            {
                Debug.Log("Success");
            };
            dbController.OnFailed = (onResolved) =>
            {
                Debug.Log("Error");
            };
            dbController.PutDBBox(objectData, environmentId);
        }
    }
}
