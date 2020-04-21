using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameObjectClass
{
    public GameObjectClass()
    {
    }

    public GameObjectClass(string name)
    {
        Name = name;
        Type = typeof(GameObject).ToString();
    }

    public GameObjectClass( GameObject go )
    {
        Name = go.name;
        Type = go.GetType().ToString();
        transformClass = new TransformClass( go.transform );
    }

    public string Name;
    public string Type;
    public string SubType;
    public TransformClass transformClass;
    public List<ComponentClass> components = new List<ComponentClass>();
    public List<GameObjectClass> children = new List<GameObjectClass>();
}


