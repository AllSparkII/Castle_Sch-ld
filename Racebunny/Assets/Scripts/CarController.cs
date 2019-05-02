using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    float steeringAngle;

    public WheelCollider frontLeftW, backLeftW, frontRightW, backRightW;
    public Transform frontLeftT, backLeftT, frontRightT, backRightT;
    public float maxSteeringAngle = 30;
    public float motorForce = 50;



    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdatewheelPoses();
    }

    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }


    private void Steer()
    {
        steeringAngle = maxSteeringAngle * horizontalInput;
        frontLeftW.steerAngle = steeringAngle;
        frontRightW.steerAngle = steeringAngle;

    }

    private void Accelerate()
    {
        frontLeftW.motorTorque = verticalInput * motorForce;
        frontRightW.motorTorque = verticalInput * motorForce;
    }

    private void UpdatewheelPoses()
    {
        UpdateWheelpose(frontLeftW, frontLeftT);
        UpdateWheelpose(frontRightW, frontRightT);
        UpdateWheelpose(backLeftW, backLeftT);
        UpdateWheelpose(backRightW, backRightT);
    }

    private void UpdateWheelpose(WheelCollider coll, Transform trans)
    {
        Vector3 pos = trans.position;
        Quaternion quat = trans.rotation;

        coll.GetWorldPose(out pos, out quat);
        trans.position = pos;
        trans.rotation = quat;
    }

}
