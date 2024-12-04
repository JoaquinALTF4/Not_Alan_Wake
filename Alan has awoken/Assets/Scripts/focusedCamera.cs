using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class focusedCamera : MonoBehaviour
{
    public Camera Camera;
    void Start()
    {
        Camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Camera.fieldOfView = Mathf.Lerp(Camera.fieldOfView,10,0.1f);
        }else{
            Camera.fieldOfView = Mathf.Lerp(Camera.fieldOfView,30,0.1f);
        }
        
    }
}
