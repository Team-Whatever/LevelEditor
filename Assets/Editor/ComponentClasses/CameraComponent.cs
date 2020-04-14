using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraComponent : ComponentClass{

    public float depth;
    public CameraComponent( Component comp )
        : base( comp )
    {
        Camera camera = comp as Camera;
        if( camera )
        {
            depth = camera.depth;
        }
    }

    public override void UpdateComponent( ref Component comp )
    {
        ( comp as Camera).depth = depth;
    }
}