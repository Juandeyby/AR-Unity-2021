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
        if (value >= 9.05f) return;
        value += 0.2f;
        ChangeValueText();
        _newObjectPanel.ChangeSize(axis, value);
    }

    public void DelValueOnClick()
    {
        if (value <= 0.25f) return;
        value -= 0.2f;
        ChangeValueText();
        _newObjectPanel.ChangeSize(axis, value);
    }

    private void ChangeValueText()
    {
        valueText.text = value.ToString("0.#");
    }

    private void OnDisable()
    {
        value = 1;
        ChangeValueText();
    }
}
