using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewObjectPanel : MonoBehaviour
{
    private GameManager _gameManager;
    private Vector3 _newSize;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.SetCurrentSize(_newSize);
    }

    private void OnEnable()
    {
        _newSize = Vector3.one;
        if (_gameManager) _gameManager.SetCurrentSize(_newSize);
    }

    public void ChangeColor(string color)
    {
        var newColor32 = new Color32(0, 0, 0, 255);
        switch (color)
        {
            case "red":
                newColor32 = new Color32(224, 41, 41, 255);
                break;
            case "green":
                newColor32 = new Color32(50, 217, 31, 255);
                break;
            case "yellow":
                newColor32 = new Color32(219, 204, 40, 255);
                break;
            case "blue":
                newColor32 = new Color32(35, 54, 212, 255);
                break;
        }
        _gameManager.SetCurrentColor(newColor32);
        HidePanelControl();
    }

    public void ChangeSize(string axis, float value)
    {
        switch (axis)
        {
            case "x":
                _newSize = new Vector3(value, _newSize.y, _newSize.z);
                break;
            case "y":
                _newSize = new Vector3(_newSize.x, value, _newSize.z);
                break;
            case "z":
                _newSize = new Vector3(_newSize.x, _newSize.y, value);
                break;
        }
        _gameManager.SetCurrentSize(_newSize);
    }

    private void HidePanelControl()
    {
        gameObject.SetActive(false);   
    }
}
