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
        title.text = obj.name;
        posX.text = obj.transform.position.x.ToString();
        posY.text = obj.transform.position.y.ToString();
        posZ.text = obj.transform.position.z.ToString();
    }

}
