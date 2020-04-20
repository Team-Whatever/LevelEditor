using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MeshRendererComponent : ComponentClass
{
    public string shaderName;
    public string materialName;

    public MeshRendererComponent( Component comp )
        : base( comp )
    {
        MeshRenderer renderer = comp as MeshRenderer;
        if( renderer != null )
        {
            shaderName = renderer.sharedMaterial.shader.name;
            materialName = renderer.sharedMaterial.name;
        }
    }

    public override void UpdateComponent( ref Component comp )
    {
        Shader shader = Shader.Find( shaderName );

        Material material = Resources.Load( materialName ) as Material;
        if( !material )
            material = new Material( shader );
        ( comp as MeshRenderer ).material = material;
    }
}
