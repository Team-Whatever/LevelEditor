using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TransformComponent : ComponentClass
{
    public Vector3 position;
    public Vector3 scale;
    public Quaternion rotation;

    public TransformComponent( Component comp )
         : base( comp )
    {
        Transform other = comp as Transform;
        if( other != null )
        {
            position = other.localPosition;
            scale = other.localScale;
            rotation = other.localRotation;
        }
    }

    public override void UpdateComponent( ref Component comp )
    {
        ( comp as Transform ).localPosition = position;
        ( comp as Transform ).localScale = scale;
        ( comp as Transform ).localRotation = rotation;
    }
}


public static class TransformExtension
{
    public static void SetComponentClass( this Transform cam, TransformComponent comp )
    {
        Debug.Log( "Call TransformExtension.SetComponentClass" );
    }
}
