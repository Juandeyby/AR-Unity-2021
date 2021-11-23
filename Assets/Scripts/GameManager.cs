using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ObjectAR _currentObjectAR;
    private int _currentXYZ;

    public ObjectAR GetObjectAR()
    {
        return _currentObjectAR;
    }
    
    public void SetObjectAR(RaycastHit objectAR)
    {
        if (_currentObjectAR) _currentObjectAR.GetComponent<MeshRenderer>().enabled = false;
        _currentObjectAR = objectAR.transform.GetComponent<ObjectAR>();
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
}
