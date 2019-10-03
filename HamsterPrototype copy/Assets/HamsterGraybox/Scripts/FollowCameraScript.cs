using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraScript : MonoBehaviour
{
    public GameObject playerHam;

    private Vector3 offset;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    public bool lookatPlayer = false;

    public bool rotateAroundPlayer = true;

    public float viewRange = 60;

    private float rotX;
    private float rotY;

    
    public float rotateSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerHam.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()//run after all items have been updated
    {
        if (rotateAroundPlayer)
        {
            /*rotX += Input.GetAxis("Mouse X") * rotateSpeed;
            rotY -= Input.GetAxis("Mouse Y") * rotateSpeed;

            rotX = Mathf.Clamp(rotX, -90f, 90f);
            rotY = Mathf.Clamp(rotY, -60f, 90f);*/
            //Quaternion camTurnAngleH = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed, Vector3.up);

            //Quaternion camTurnAngleV = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * rotateSpeed, Vector3.right);



            //offset = camTurnAngleV * camTurnAngleH * offset;
            //offset = camTurnAngleH * offset;

        }

        Vector3 newPos = playerHam.transform.position + offset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);


        if (lookatPlayer || rotateAroundPlayer)
            transform.LookAt(playerHam.gameObject.transform);

    }
}
