using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntSize : MonoBehaviour
{
    [SerializeField] private string axis;
    [SerializeField] private TMP_Text valueText;
    private NewObjectPanel _newObjectPanel;
    private float value = 1f;

    private void Start()
    {
        _newObjectPanel = FindObjectOfType<NewObjectPanel>();
    }

    public void AddValueOnClick()
    {
        if (value >= 200f) return;
        value += 1f;
        ChangeValueText();
        _newObjectPanel.ChangeSize(axis, value);
    }

    public void DelValueOnClick()
    {
        if (value <= 1f) return;
        value -= 1f;
        ChangeValueText();
        _newObjectPanel.ChangeSize(axis, value);
    }

    private void ChangeValueText()
    {
        valueText.text = value.ToString("0.# cm");
    }

    private void OnEnable()
    {
        value = DataManager.GetConfigData().boxScale;
        ChangeValueText();
    }

    private void OnDisable()
    {
        value = 1;
        ChangeValueText();
    }
}
