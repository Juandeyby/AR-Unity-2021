using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectARData
{
    public string id;
    
    public float xPosition;
    public float yPosition;
    public float zPosition;

    public float xRotation;
    public float yRotation;
    public float zRotation;

    public int rColor;
    public int gColor;
    public int bColor;

    public int size;
    
    public ObjectARData()
    {
        id = Tools.ShortUnique();
    }

    public ObjectARData(string id, float xPosition, float yPosition, float zPosition, float xRotation, float yRotation, float zRotation, int rColor, int gColor, int bColor, int size)
    {
        this.id = id;
        this.xPosition = xPosition;
        this.yPosition = yPosition;
        this.zPosition = zPosition;
        this.xRotation = xRotation;
        this.yRotation = yRotation;
        this.zRotation = zRotation;
        this.rColor = rColor;
        this.gColor = gColor;
        this.bColor = bColor;
        this.size = size;
    }
    
    public ObjectARData(ObjectAR objectAR)
    {
        id = objectAR.id;
        var transform = objectAR.transform;
        var position = transform.position;
        xPosition = position.x;
        yPosition = position.y;
        zPosition = position.z;
        var rotation = transform.rotation.eulerAngles;
        xRotation = rotation.x;
        yRotation = rotation.y;
        zRotation = rotation.z;
        this.rColor = rColor;
        this.gColor = gColor;
        this.bColor = bColor;
        size = (int) transform.localScale.x;
    }
}
