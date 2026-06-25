using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] private WheelCollider Frontleftwheelcollider; // ya variable WheelCollider ha jis ma hum FrontRightwheel ko as referce wheelcollider ha sakta ha
    [SerializeField] private WheelCollider FrontRightWheelCollider; 
    [SerializeField] private WheelCollider backleftwheelCollider; 
    [SerializeField] private WheelCollider backRightwheelCollider; 

    [SerializeField] private Transform FrontleftwheelTransform; // ya wheel ki movement ka lya hm na variable declare kia ha
    [SerializeField] private Transform FrontRightWheelTransform;  
    [SerializeField] private Transform backleftwheelTransform; 
    [SerializeField] private Transform backRightwheelTransform; 

    [SerializeField] private Transform carCenterOfMassTransform;
    
    [SerializeField] private float motorForce = 450f;
    [SerializeField] private float steeringAngle = 30f;
    [SerializeField] private float brakeForce = 1000f;
    [SerializeField] private float launchBoostMultiplier = 3.8f;
    [SerializeField] private float lowSpeedThreshold = 50f;
    [SerializeField] private float maxSpeedMph = 250f;

    [SerializeField] UiManager uIManager;

    private Rigidbody rb;
    private float verticalInput;
    private float horizontalInput;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = carCenterOfMassTransform.localPosition;
    }

    public void SetUiManager(UiManager manager)
    {
        uIManager = manager;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInput();
        MotorForce();
        updateWheels();
        steering();
        ApplyBrakes();
        powerSteering();
        LimitTopSpeed();
    } 

    void GetInput()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    void ApplyBrakes()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            FrontRightWheelCollider.brakeTorque = brakeForce;
            backRightwheelCollider.brakeTorque = brakeForce;
            Frontleftwheelcollider.brakeTorque = brakeForce;
            backleftwheelCollider.brakeTorque = brakeForce;
            rb.linearDamping = 1f;
        }
        else 
        {
            FrontRightWheelCollider.brakeTorque = 0f;
            backRightwheelCollider.brakeTorque = 0f;
            Frontleftwheelcollider.brakeTorque = 0f;
            backleftwheelCollider.brakeTorque = 0f;
            rb.linearDamping = 0f;
        }
    }

    void MotorForce() // ya hm na method create kia ha
    {
        float currentSpeed = CarSpeed();
        if (verticalInput > 0f && currentSpeed >= maxSpeedMph)
        {
            FrontRightWheelCollider.motorTorque = 0f;
            Frontleftwheelcollider.motorTorque = 0f;
            return;
        }

        float speedRatio = Mathf.Clamp01(currentSpeed / lowSpeedThreshold);
        float boost = Mathf.Lerp(launchBoostMultiplier, 1f, speedRatio);
        float effectiveInput = verticalInput;

        if (verticalInput > 0f)
        {
            effectiveInput *= boost;
        }

        FrontRightWheelCollider.motorTorque = motorForce * effectiveInput;
        Frontleftwheelcollider.motorTorque = motorForce * effectiveInput;
    }

    void steering()
    {
        float targetAngle = steeringAngle * horizontalInput;

        FrontRightWheelCollider.steerAngle = steeringAngle * horizontalInput;
        Frontleftwheelcollider.steerAngle = steeringAngle * horizontalInput;
    }

    void powerSteering()
    {
        if (horizontalInput == 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime);
        }
    }

    void updateWheels()
    {
        // we call the rotation method
        RotateWheel(Frontleftwheelcollider, FrontleftwheelTransform);
        RotateWheel(FrontRightWheelCollider, FrontRightWheelTransform);
        RotateWheel(backleftwheelCollider, backleftwheelTransform);
        RotateWheel(backRightwheelCollider, backRightwheelTransform);
    }

    // WheelCollider ya parameter ha second WheelCollider us ka name ja same for transform.
    void RotateWheel(WheelCollider wheelCollider, Transform transformWheel)
    {
        Vector3 pos; // position
        Quaternion rot; // rotation
        wheelCollider.GetWorldPose(out pos, out rot);
        transformWheel.position = pos;
        transformWheel.rotation = rot;
    }

    public float CarSpeed()
    {
        float speed = rb.linearVelocity.magnitude * 2.23693629f;
        return speed;
    }

    void LimitTopSpeed()
    {
        float maxSpeedMetersPerSecond = maxSpeedMph / 2.23693629f;
        if (rb.linearVelocity.magnitude > maxSpeedMetersPerSecond)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeedMetersPerSecond;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TrafficVehicle"))
        {
            if (uIManager != null)
            {
                uIManager.gameOver();
            }
        }
    }
}

