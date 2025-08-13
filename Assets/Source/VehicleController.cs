using UnityEngine;
using System;
using System.Collections.Generic;

public enum Axle
{
    Front,
    Rear
}


public enum DriveTrain
{
    FWD,
    RWD,
    AWD
}

[Serializable]
public struct Wheel
{
    public GameObject wheelModel; // The visual representation of the wheel
    public Transform WheelTransform;
    public WheelCollider wheelCollider;
    public Axle WheelAxle;
    public Wheel(GameObject Model, Transform transform, WheelCollider collider, Axle axle)
    {
        wheelModel = Model;
        WheelTransform = transform;
        wheelCollider = collider;
        WheelAxle = axle;
    }
}


public class VehicleController : MonoBehaviour
{

    [Header("Vehicle Settings")]
    public float maxMotorTorque = 1500f;
    public float maxSteeringAngle = 35f;
    
    public List<Wheel> wheels = new List<Wheel>();
    public DriveTrain driveTrain;


    [Header("Physics Settings")]
    public Vector3 CenterOfMassOffset;
    private Rigidbody VehicleRB;
    float Throttle;
    float Steering;


    void Start()
    {
        VehicleRB = GetComponent<Rigidbody>();
        VehicleRB.centerOfMass = CenterOfMassOffset;
    }

    void GetInputs()
    {
        //* Currently controlled through user input for purposes of testing
        //* This will be substituted for a proper API with the coding blocks

        Throttle = Input.GetAxis("Vertical");
        Steering = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        GetInputs();
        Move();
    }

    void Move()
    {
        float steeringAngle = Steering * maxSteeringAngle;

        foreach (Wheel wheel in wheels)
        {
            float motorTorque = Throttle * maxMotorTorque;

            bool canApplyTorque =
                    (driveTrain == DriveTrain.AWD) ||
                    (driveTrain == DriveTrain.FWD && wheel.WheelAxle == Axle.Front) ||
                    (driveTrain == DriveTrain.RWD && wheel.WheelAxle == Axle.Rear);

            wheel.wheelCollider.motorTorque = canApplyTorque ? motorTorque : 0f;

            // Apply steering only to front axle
            if (wheel.WheelAxle == Axle.Front)
            {
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, steeringAngle, Time.deltaTime * 5f);
            }

            UpdateWheelVisuals(wheel);
        }

    }

    void UpdateWheelVisuals(Wheel wheel)
    {
        Vector3 pos; Quaternion rot;
        wheel.wheelCollider.GetWorldPose(out pos, out rot);

        Quaternion meshRotationOffset = Quaternion.Euler(0f, 0f, 90f);

        wheel.wheelModel.transform.position = pos;
        wheel.wheelModel.transform.rotation = rot * meshRotationOffset;
    }
}
