using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LightComponent : ComponentClass
{
    public LightType lightType;
    public Color color;
    public LightmapBakeType lightMode;
    public float intensity;
    public LightShadows shadowType;
    public LightComponent( Component comp )
        : base( comp )
    {
        Light light = comp as Light;
        if( light != null )
        {
            lightType = light.type;
            color = light.color;
            lightMode = light.lightmapBakeType;
            intensity = light.intensity;
            shadowType = light.shadows;
        }
    }

    public override void UpdateComponent( ref Component comp )
    {
        ( comp as Light ).type = lightType;
        ( comp as Light ).color = color;
        ( comp as Light ).lightmapBakeType = lightMode;
        ( comp as Light ).intensity = intensity;
        ( comp as Light ).shadows = shadowType;
    }

}
