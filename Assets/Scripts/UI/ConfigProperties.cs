using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfigProperties : MonoBehaviour
{
    [SerializeField] private List<TMP_InputField> inputFieldValues;

    public List<int> GetValues()
    {
        var valuesTemp = new List<int>();
        foreach (var inputField in inputFieldValues)
        {
            valuesTemp.Add(int.Parse(inputField.text));
        }
        return valuesTemp;
    }

    public int GetValue()
    {
        return int.Parse(inputFieldValues[0].text);
    }

    public void SetValues(List<int> valuesTemp)
    {
        Debug.Log(valuesTemp[0] + "---" + valuesTemp[1]);
        for (var i = 0; i < inputFieldValues.Count; i++)
        {
            inputFieldValues[i].text = valuesTemp[i].ToString();
        }
    }

    public void SetValues(float valueTemp)
    {
        inputFieldValues[0].text = valueTemp.ToString();
    }
}
