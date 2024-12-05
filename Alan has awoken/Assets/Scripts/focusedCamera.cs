using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class focusedCamera : MonoBehaviour
{
    public Camera Camera;
    float minenemySpeed;
    float enemySpeed;
    void Start()
    {
        minenemySpeed = enemySpeed;
        Camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Camera.fieldOfView = Mathf.Lerp(Camera.fieldOfView,10,0.1f);
            enemySpeed = minenemySpeed;
        }else{
            Camera.fieldOfView = Mathf.Lerp(Camera.fieldOfView,30,0.1f);
        }
        
    }
}
