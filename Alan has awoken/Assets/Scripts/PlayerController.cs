using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera camera;
    private Transform cameraRotationPoint;
    public Rigidbody playerBody;
    public float movementSpeed;
    public float lookSpeed;
    public float cameraDistance;
    public Transform playerCameraRotation;
    public GameObject flashlight;
    public bool lightOn = true;
    float xInput = 0;
    float yInput = 0;
    float xMouse = 0;
    float yMouse = 0;
    float xRotation = 0;
    float yRotation = 0;
    public Vector3 cameraOffset = new Vector3(0f,0f,0f);
    private float cameraMoveTime = 0;
    void Start()
    {
        Rigidbody playerBody = GetComponent<Rigidbody>();
        camera = GetComponentInChildren<Camera>();
        flashlight = transform.GetChild(1).gameObject;
        cameraOffset = camera.transform.localPosition;
        cameraRotationPoint = transform.GetChild(0);
        cameraRotationPoint.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        xMouse = Input.GetAxisRaw("Mouse X");
        yMouse = Input.GetAxisRaw("Mouse Y");
        if(Input.GetKeyDown(KeyCode.F))
            if(lightOn == false) 
            {
                LightOn();
            }
            else{
                LightOff();
            }

        xRotation += -yMouse * lookSpeed * Time.deltaTime;
        yRotation += xMouse * lookSpeed * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation,-90,90);


        cameraRotationPoint.transform.rotation = Quaternion.Euler(
          0, yRotation + 90, xRotation
        );
        transform.rotation = Quaternion.Euler(
            0, yRotation, 0
        );
        cameraRotationPoint.transform.position = transform.position;
        
        //Vector3 cameraTargetPosition = transform.position - (camera.transform.forward * cameraDistance);

        //camera.transform.position = Vector3.Slerp(camera.transform.position, cameraTargetPosition,cameraMoveTime);
        cameraMoveTime += Time.deltaTime;



    }

    void PlayerMovement(){
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        playerBody.AddRelativeForce(
            new Vector3(
                xInput,0,yInput
            ) * movementSpeed
            );
       
    }
    void LightOn()
    {
         flashlight.SetActive(true);
    lightOn = true;
    Debug.Log("This is Working");

    }
   void LightOff()
   {
    flashlight.SetActive(false);
    lightOn = false;
    Debug.Log("this is working");
   }
   


}
