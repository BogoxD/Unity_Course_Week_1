using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel_Steer : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] float carSpeed = 2f;

    [Header("Car Rotation")]
    [SerializeField] float WheelRotationRange = 25f;
    [SerializeField] float rotationSpeed = 2f;

    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        OnInput();
    }
    private void OnInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(horizontal != 0)
        {
            transform.Rotate(new Vector3(0, rotationSpeed * horizontal * Time.deltaTime, 0));
            LimitRotation();
        }
        if(vertical != 0)
        {
            _rb.AddForce(transform.forward * vertical * carSpeed, ForceMode.Force);
        }

    }
    private void LimitRotation()
    {
        Vector3 wheelEulerAngle = transform.rotation.eulerAngles;

        wheelEulerAngle.y = (wheelEulerAngle.y > 180)? wheelEulerAngle.y - 360 : wheelEulerAngle.y;
        wheelEulerAngle.y = Mathf.Clamp(wheelEulerAngle.y, -WheelRotationRange, WheelRotationRange);
        transform.localRotation = Quaternion.Euler(wheelEulerAngle);
    }
    private void ResetForward()
    {
        transform.forward = transform.parent.forward;
    }
}
