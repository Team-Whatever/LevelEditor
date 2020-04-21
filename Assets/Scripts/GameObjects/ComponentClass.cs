using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ComponentClass
{
    public ComponentClass()
    {

    }
    public ComponentClass( Component comp )
    {
        if( comp != null )
            Type = comp.GetType().ToString();
    }

    public virtual void UpdateComponent( ref Component comp )
    {
    }
    public string Type;
}