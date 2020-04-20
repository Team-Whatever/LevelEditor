using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

public static class ComponentFactory
{
    static Dictionary<Type, Type> ComponentTypeMap = new Dictionary<Type, Type>()
    {
        { typeof(Transform), typeof(TransformComponent) },
        { typeof(Camera), typeof(CameraComponent) },
        { typeof(Light), typeof(LightComponent) },
        { typeof(BoxCollider), typeof(BoxColliderComponent) },
        { typeof(CapsuleCollider), typeof(CapsuleColliderComponent) },
        { typeof(SphereCollider), typeof(SphereColliderComponent) },
        { typeof(MeshRenderer), typeof(MeshRendererComponent) },
        { typeof(MeshFilter), typeof(MeshFilterComponent) }
    };

    public static ComponentClass CreateComponentClass<T>( T comp ) where T : Component
    {
        if( ComponentTypeMap.ContainsKey( comp.GetType() ) )
        {
            return Activator.CreateInstance( ComponentTypeMap[comp.GetType()], new object[] { comp } ) as ComponentClass;
        }
        return new ComponentClass( comp );
    }

    public static void CreateComponent<T>( this GameObject go, T compClass ) where T : ComponentClass
    {
        Type compClassType = Type.GetType( compClass.Type + ", UnityEngine" );
        if( compClassType == typeof( Transform ) )
        {
            // Transform component is already added to the gameobject by default
            return;
        }

        Component comp = go.AddComponent( compClassType );
        if( comp != null )
        {
            if( ComponentTypeMap.ContainsKey( compClassType ) )
            {
                compClass.UpdateComponent( ref comp );
            }
            comp.transform.parent = go.transform;
        }
        else
        {
            Debug.Assert( false, "Unknown componenet added : " + compClass.Type );
        }

    }


}
