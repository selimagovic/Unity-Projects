using UnityEngine;
using System.Collections;

public class MotorMovement : MonoBehaviour {

	//reference to wheel joint
	public WheelJoint2D[] wheelJoint;
	//reference to Motor joint
	public JointMotor2D motorBack;
	//center of Mass of Motor
	public Transform centerOfMass;
	//reference to the wheels
	public Rigidbody2D rb;
	public Transform rearWheel;
	public Transform frontWheel;
	float dir = 0f; //horizontal movement keyboard input
	float torqueDir = 0f; //input for rotation of the car
	float maxFwdSpeed = -8000f; //max forward speed which the car can move at
	float maxBwdSpeed = 2000f; //max bwd speed
	float accelrationRate = 700; //the rate at which the car accelerates
	float decelerationRate = -100f; //the rate at which the car decelerates
	float brakeSpeed = 4000f; //how soon the car stops on braking
	float gravity = 9.81f; //acceleration due to gravity
	float slope = 0;
    public bool isgrounded = false;
    public Transform groundedPlayer;
    public float jumpForce,radius;
    public LayerMask ground;
    //angle in wich the car is at wrt the ground

    //Audio Sounds
    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        rb.centerOfMass = centerOfMass.transform.localPosition;
		wheelJoint = gameObject.GetComponents<WheelJoint2D> ();
        motorBack = wheelJoint[0].motor;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        isgrounded = Physics2D.OverlapCircle(groundedPlayer.transform.position, radius, ground);
        if (Input.GetKey(KeyCode.J) && isgrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxBwdSpeed);
        }
        //add ability to rotate the car around its axis
        torqueDir = Input.GetAxis("Horizontal");
        if (torqueDir != 0)
            rb.AddTorque(3 * Mathf.PI * torqueDir, ForceMode2D.Force);
        else
            rb.AddTorque(0);

        //determine the cars angle wrt the horizontal ground
        slope = transform.localEulerAngles.z;
        //convert the slope values greater than 180 to a negative value so as to add motor speed
        //based on the slope angle
        if (slope >= 180)
            slope -= 360;

        //horizontal movement input same as torque dir. could have avoided it, but decided to
        //use it since some of you might want to use the Vertical axis for the torqueDir
        dir = Input.GetAxis("Horizontal");

        if (dir != 0)
        {
            motorBack.motorSpeed = Mathf.Clamp(motorBack.motorSpeed -
            (dir * accelrationRate - gravity * Mathf.Sin((slope * Mathf.PI) / 180) * 80) * Time.deltaTime,
                maxFwdSpeed, maxBwdSpeed);
        }

        if ((dir == 0 && motorBack.motorSpeed < 0) || (dir == 0 && motorBack.motorSpeed == 0 && slope < 0)) {
            motorBack.motorSpeed = Mathf.Clamp(motorBack.motorSpeed -
            (decelerationRate - gravity * Mathf.Sin((slope * Mathf.PI) / 180) * 80) * Time.deltaTime,
                maxFwdSpeed, 0);

        }
        else if ((dir == 0 && motorBack.motorSpeed < 0) || (dir == 0 && motorBack.motorSpeed == 0
                && slope < 0))
        {
            motorBack.motorSpeed = Mathf.Clamp(motorBack.motorSpeed -
                (-decelerationRate - gravity * Mathf.Sin((slope * Mathf.PI) / 180) * 80) * Time.deltaTime,
                0, maxBwdSpeed);
        }
        
        //apply brakes to the motor
        if (Input.GetKey (KeyCode.Space) && motorBack.motorSpeed > 0)
			motorBack.motorSpeed = Mathf.Clamp (motorBack.motorSpeed - brakeSpeed * Time.deltaTime,
				0, maxBwdSpeed);
		else
			if(Input.GetKey (KeyCode.Space) && motorBack.motorSpeed < 0)
				motorBack.motorSpeed = Mathf.Clamp (motorBack.motorSpeed + brakeSpeed * Time.deltaTime,
					maxFwdSpeed, 0);

		wheelJoint[0].motor = motorBack;
	}
}
