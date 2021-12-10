using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public List<Button> transformButtons;
    [SerializeField] private Toggle toggleActive, toggleDesactive;
    private GameManager _gameManager;
    private int _transformId;
    private GameObject _gameObjectToCreate;
    private bool _isObjectCreating;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public int GetTransformId()
    {
        return _transformId;
    }

    public GameObject GetObjectARCreate()
    {
        return _gameObjectToCreate;
    }

    public void SetEmptyObjectPrefabAR()
    {
        _gameObjectToCreate = null;
        DisableCreating();
    }

    public void DisableCreating()
    {
        _isObjectCreating = false;
    }

    public bool isCreating()
    {
        return _isObjectCreating;
    }

    public void ItemOnClick(GameObject namePrefab)
    {
        _isObjectCreating = true;
        _gameObjectToCreate = namePrefab;
        _gameManager.ShowPanelControl();
    }

    public void XYZOnClick(int value)
    {
        _gameManager.SetCurrentAxis(value);
    }

    public void ActiveOnClick(bool active)
    {
        if (_gameManager.GetObjectAR() == null) return;
        _gameManager.GetObjectAR().SetActive(active);
    }

    public void SetActive(bool active)
    {
        if (active)
        {
            toggleActive.isOn = active;
            toggleDesactive.isOn = !active;
        }
        else
        {
            toggleActive.isOn = active;
            toggleDesactive.isOn = !active;
        }
    }

    public void PositionOnClick(Button button)
    {
        ChangeButtons(button);
        _transformId = 0; // 0 = Position
    }

    public void RotationOnClick(Button button)
    {
        ChangeButtons(button);
        _transformId = 1; // 1 = Rotation
    }
    
    public void ScaleOnClick(Button button)
    {
        ChangeButtons(button);
        _transformId = 2; // 1 = Rotation
    }

    public void RemoveOnClick()
    {
        _gameManager.RemoveObjectAR();
    }

    private void ChangeButtons(Button currentButton)
    {
        foreach (var button in transformButtons)
        {
            if (currentButton == button)
            {
                ChangeColorButton(button, true);
                continue;
            } 
            ChangeColorButton(button, false);
        }
    }
    
    private void ChangeColorButton(Button button, bool active)
    {
        var colorBlock = button.colors;
        if (active)
        {
            colorBlock.selectedColor = Color.red;
            colorBlock.normalColor = Color.red;   
        }
        else
        {
            colorBlock.selectedColor = Color.white;
            colorBlock.normalColor = Color.white;
        }
        button.colors = colorBlock;
    }
}