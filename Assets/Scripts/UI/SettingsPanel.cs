using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private List<ConfigProperties> _configPropertiesList;

    private void OnEnable()
    {
        var dataManager = DataManager.GetConfigData();
        _configPropertiesList[0].SetValues(dataManager.firstColor);
        _configPropertiesList[1].SetValues(dataManager.secondColor);
        _configPropertiesList[2].SetValues(dataManager.thirdColor);
        _configPropertiesList[3].SetValues(dataManager.fourthColor);
        _configPropertiesList[4].SetValues(dataManager.boxScale);
        _configPropertiesList[5].SetValues(dataManager.gridScale);
    }
    
    private void SetValuesOnClick()
    {
        var configData = new ConfigData();
        configData.firstColor = _configPropertiesList[0].GetValues();
        configData.secondColor = _configPropertiesList[1].GetValues();
        configData.thirdColor = _configPropertiesList[2].GetValues();
        configData.fourthColor = _configPropertiesList[3].GetValues();
        configData.boxScale = _configPropertiesList[4].GetValue();
        configData.gridScale = _configPropertiesList[5].GetValue();
        DataManager.SaveData(configData);
    }

    public void CloseOnClick()
    {
        SetValuesOnClick();
        DataManager.LoadData();
        gameObject.SetActive(false);
    }
}
