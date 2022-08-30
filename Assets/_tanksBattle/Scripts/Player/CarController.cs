using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private DynamicJoystick _dynamicJoystick;
    [SerializeField] private float _motorForce;
    [SerializeField] private float _breakForce;
    [SerializeField] private float _maxSteerAngle;
    [SerializeField] private WheelCollider _frontLeftCollider;
    [SerializeField] private WheelCollider _frontRightCollider;
    [SerializeField] private WheelCollider _backLeftCollider;
    [SerializeField] private WheelCollider _backRightCollider;

    [SerializeField] private Transform _frontLeftTransform;
    [SerializeField] private Transform _frontRightTransform;
    [SerializeField] private Transform _backLeftTransform;
    [SerializeField] private Transform _backRightTransform;



    private float _horizontalInput;
    private float _verticalInput;
    private float _steerAngle;

    private float _currentBreakForce;
    private bool _isBraking;





    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    

    private void GetInput()
    {
        _horizontalInput = _dynamicJoystick.Horizontal;
        _verticalInput = _dynamicJoystick.Vertical * -1;
        _isBraking = Input.GetKey(KeyCode.Space);
    }
    private void HandleMotor()
    {
        _frontLeftCollider.motorTorque = _verticalInput * _motorForce;
        _frontRightCollider.motorTorque = _verticalInput * _motorForce;
        _currentBreakForce = _isBraking ? _breakForce : 0;

        if (_isBraking == true)
        {
            ApplyBreaking();
        }
    }
    private void ApplyBreaking()
    {
        _frontLeftCollider.brakeTorque = _currentBreakForce; 
       _frontRightCollider.brakeTorque = _currentBreakForce;
         _backLeftCollider.brakeTorque = _currentBreakForce;
        _backRightCollider.brakeTorque = _currentBreakForce;
    }
    private void HandleSteering()
    {
        _steerAngle = _maxSteerAngle * _horizontalInput;
        _frontLeftCollider.steerAngle = _steerAngle;
        _frontRightCollider.steerAngle = _steerAngle;
    }
    private void UpdateWheels()
    {
        UpdateSingleWheel(_frontLeftCollider, _frontLeftTransform);
        UpdateSingleWheel(_frontRightCollider, _frontRightTransform);
        UpdateSingleWheel(_backLeftCollider, _backLeftTransform);
        UpdateSingleWheel(_backRightCollider, _backRightTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;


        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
