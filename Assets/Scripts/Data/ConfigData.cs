using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConfigData
{
    public List<int> firstColor;
    public List<int> secondColor;
    public List<int> thirdColor;
    public List<int> fourthColor;
    
    public int boxScale;
    public int gridScale;
    
    public ConfigData()
    {
        firstColor = new List<int>();
        secondColor = new List<int>();
        thirdColor = new List<int>();
        fourthColor = new List<int>();

        SetValuesDefault();
    }

    private void SetValuesDefault()
    {
        firstColor.Add(224);
        firstColor.Add(41);
        firstColor.Add(41);
        
        secondColor.Add(50);
        secondColor.Add(217);
        secondColor.Add(31);
        
        thirdColor.Add(219);
        thirdColor.Add(204);
        thirdColor.Add(40);
        
        fourthColor.Add(35);
        fourthColor.Add(54);
        fourthColor.Add(212);

        boxScale = 10;
        gridScale = 5;
    }
}
