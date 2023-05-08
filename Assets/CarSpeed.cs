using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpeed : MonoBehaviour
{
    public float maxSpeed = 50.0f;
    public float acceleration = 10.0f;
    public float deceleration = 20.0f;

    private Rigidbody carBody;

    private void Start()
    {
        carBody = GetComponent<Rigidbody>();
        LogitechGSDK.LogiSteeringInitialize(false);
    }

    private void FixedUpdate()
    {
        // Get steering input from G29
        float steeringInput = LogitechGSDK.LogiGetSteeringWheelValue(0);

        // Map steering input to car's turning
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation.y += steeringInput * Time.deltaTime * 100.0f;
        transform.rotation = Quaternion.Euler(rotation);

        // Get accelerator and brake input from G29
        float acceleratorInput = LogitechGSDK.LogiGetPedalValue(0);
        float brakeInput = LogitechGSDK.LogiGetPedalValue(1);

        // Map accelerator and brake input to car's speed
        float speed = carBody.velocity.magnitude;
        if (acceleratorInput > 0)
        {
            carBody.AddForce(transform.forward * acceleration * acceleratorInput);
        }
        else if (brakeInput > 0)
        {
            carBody.AddForce(transform.forward * -deceleration * brakeInput);
        }
        else if (speed > 0)
        {
            carBody.AddForce(transform.forward * -deceleration);
        }

        // Limit maximum speed
        if (speed > maxSpeed)
        {
            carBody.velocity = carBody.velocity.normalized * maxSpeed;
        }
    }

    private void OnDestroy()
    {
        LogitechGSDK.LogiSteeringShutdown();
    }
}