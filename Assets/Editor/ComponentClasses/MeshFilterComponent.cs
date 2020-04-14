using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
class MeshFilterComponent : ComponentClass
{
    public Mesh mesh;
    public string meshName;
    public MeshFilterComponent()
        : base()
    {
    }
    public MeshFilterComponent( Component comp )
        : base( comp )
    {
        MeshFilter meshFilter = comp as MeshFilter;
        if( meshFilter != null )
        {
            mesh = meshFilter.sharedMesh;
            meshName = meshFilter.name;
        }
    }

    public override void UpdateComponent( ref Component comp )
    {
        ( comp as MeshFilter ).mesh = mesh;
    }
}
