using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewObjectPanel : MonoBehaviour
{
    private GameManager _gameManager;
    private Vector3 _newSize;
    [SerializeField] private List<Button> boxColors;

    private void GetConfigData()
    {
        var configColor = DataManager.GetConfigData();
        boxColors[0].image.color = ConvertIntToColor(configColor.firstColor);
        boxColors[1].image.color = ConvertIntToColor(configColor.secondColor);
        boxColors[2].image.color = ConvertIntToColor(configColor.thirdColor);
        boxColors[3].image.color = ConvertIntToColor(configColor.fourthColor);
    }

    private Color32 ConvertIntToColor(List<int> colors)
    {
        return new Color32(
            (byte) colors[0],
            (byte) colors[1],
            (byte) colors[2],
            255
            );
    }

    private void OnEnable()
    {
        _gameManager = FindObjectOfType<GameManager>();
        var boxScale = DataManager.GetConfigData().boxScale;
        Debug.Log(boxScale);
        _newSize = new Vector3(boxScale, boxScale, boxScale);
        if (_gameManager)
        {
            _gameManager.SetCurrentSize(_newSize);
            Debug.Log(_newSize.x);
        }
        GetConfigData();
    }

    public void ChangeColor(string color)
    {
        var newColor32 = new Color32(0, 0, 0, 255);
        switch (color)
        {
            case "0":
                newColor32 = boxColors[0].image.color;
                break;
            case "1":
                newColor32 = boxColors[1].image.color;
                break;
            case "2":
                newColor32 = boxColors[2].image.color;
                break;
            case "3":
                newColor32 = boxColors[3].image.color;
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
