using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PrimitiveType
{
    Cube,
    Sphere,
    Cylinder,
    Cone,
    Torus
}

public class LeftPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSceneLoad()
    {

    }

    public void OnSceneSave()
    {

    }

    public void OnPrimitiveClicked( GameObject buttonObject )
    {
        GameObject primitiveObject = buttonObject.GetComponent<PrimitiveObject>().prefab;
        LevelEditorMain.Instance.BeginPrimitiveObject( primitiveObject );
    }

    public void OnPlaneClicked()
    {

    }
}
