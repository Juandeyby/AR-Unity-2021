using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public List<Button> transformButtons;
    private GameManager _gameManager;
    private int _transformId;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public int GetTransformId()
    {
        return _transformId;
    }

    public void ItemOnClick(GameObject namePrefab)
    {
        Instantiate(namePrefab);
    }

    public void XYZOnClick(int value)
    {
        _gameManager.SetCurrentAxis(value);
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