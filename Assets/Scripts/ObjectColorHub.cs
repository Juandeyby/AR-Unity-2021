using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectColorHub : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void ChangeColor(string color)
    {
        var color32 = new Color32(0, 0, 0, 255);
        switch (color)
        {
            case "red":
                color32 = new Color32(224, 41, 41, 255);
                break;
            case "green":
                color32 = new Color32(50, 217, 31, 255);
                break;
            case "yellow":
                color32 = new Color32(219, 204, 40, 255);
                break;
            case "blue":
                color32 = new Color32(35, 54, 212, 255);
                break;
        }
        _gameManager.SetCurrentColor(color32);
        HidePanelControl();
    }

    private void HidePanelControl()
    {
        gameObject.SetActive(false);   
    }
}
