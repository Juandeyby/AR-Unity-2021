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
    private int value = 1;

    private void Start()
    {
        _newObjectPanel = FindObjectOfType<NewObjectPanel>();
    }

    public void AddValueOnClick()
    {
        if (value >= 9) return;
        value++;
        ChangeValueText();
        _newObjectPanel.ChangeSize(axis, value);
    }

    public void DelValueOnClick()
    {
        if (value <= 1) return;
        value--;
        ChangeValueText();
        _newObjectPanel.ChangeSize(axis, value);
    }

    private void ChangeValueText()
    {
        valueText.text = value.ToString();
    }

    private void OnDisable()
    {
        value = 1;
        ChangeValueText();
    }
}
