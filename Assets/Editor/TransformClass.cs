using System;
using UnityEngine;

[Serializable]
public class TransformClass
{
    public Vector3 position;
    public Vector3 scale;
    public Quaternion rotation;
    public TransformClass()
    {

    }
    public TransformClass( Transform other )
    {
        position = other.localPosition;
        scale = other.localScale;
        rotation = other.localRotation;
    }
}

