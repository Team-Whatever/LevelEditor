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
    public InputField rotX;
    public InputField rotY;
    public InputField rotZ;
    public InputField scaleX;
    public InputField scaleY;
    public InputField scaleZ;

    private void Awake()
    {
        scaleX.onEndEdit.AddListener( OnScaleXChanged );
        scaleY.onEndEdit.AddListener( OnScaleYChanged );
        scaleZ.onEndEdit.AddListener( OnScaleZChanged );
    }

    public void SetGameObject( GameObject obj )
    {
        targetObject = obj;

    }

    public void UpdateUI()
    {
        if( targetObject != null )
        {
            title.text = targetObject.name;
            posX.text = targetObject.transform.position.x.ToString();
            posY.text = targetObject.transform.position.y.ToString();
            posZ.text = targetObject.transform.position.z.ToString();

            rotX.text = targetObject.transform.eulerAngles.x.ToString();
            rotY.text = targetObject.transform.eulerAngles.y.ToString();
            rotZ.text = targetObject.transform.eulerAngles.z.ToString();

            scaleX.text = targetObject.transform.localScale.x.ToString();
            scaleY.text = targetObject.transform.localScale.y.ToString();
            scaleZ.text = targetObject.transform.localScale.z.ToString();
        }
        else
        {
            title.text = string.Empty;
            posX.text = string.Empty;
            posY.text = string.Empty;
            posZ.text = string.Empty;
            rotX.text = string.Empty;
            rotY.text = string.Empty;
            rotZ.text = string.Empty;
            scaleX.text = string.Empty;
            scaleY.text = string.Empty;
            scaleZ.text = string.Empty; 
        }
    }

    public void OnScaleXChanged( string newValue )
    {
        Debug.Log( "new value = " + newValue );
        if( targetObject != null )
        {
            float newScale;
            if( float.TryParse( newValue, out newScale ) )
            {
                Vector3 newScaleVector = targetObject.transform.localScale;
                newScaleVector.x = newScale;
                targetObject.transform.localScale = newScaleVector;
                UpdateUI();
            }
        }
    }

    public void OnScaleYChanged( string newValue )
    {
        Debug.Log( "new value = " + newValue );
        if( targetObject != null )
        {
            float newScale;
            if( float.TryParse( newValue, out newScale ) )
            {
                Vector3 newScaleVector = targetObject.transform.localScale;
                newScaleVector.y = newScale;
                targetObject.transform.localScale = newScaleVector;
                UpdateUI();
            }
        }
    }

    public void OnScaleZChanged( string newValue )
    {
        Debug.Log( "new value = " + newValue );
        if( targetObject != null )
        {
            float newScale;
            if( float.TryParse( newValue, out newScale ) )
            {
                Vector3 newScaleVector = targetObject.transform.localScale;
                newScaleVector.z = newScale;
                targetObject.transform.localScale = newScaleVector;
                UpdateUI();
            }
        }
    }

}
