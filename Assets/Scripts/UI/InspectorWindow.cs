using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorWindow : MonoBehaviour
{
    public GameObject targetObject;

    public InputField title;
    public InputField posX;
    public InputField posY;
    public InputField posZ;

    public void SetGameObject( GameObject obj )
    {
        targetObject = obj;
    }

    public void Update()
    {
        if( targetObject != null )
        {
            title.text = targetObject.name;
            posX.text = targetObject.transform.position.x.ToString();
            posY.text = targetObject.transform.position.y.ToString();
            posZ.text = targetObject.transform.position.z.ToString();
        }
        else
        {
            title.text = string.Empty;
            posX.text = string.Empty;
            posY.text = string.Empty;
            posZ.text = string.Empty;
        }
        
    }

}
