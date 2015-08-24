using UnityEngine;

public class MovePlayerShip : MonoBehaviour 
{
	public float forwardThrustForce;
	public float rotationalForce;
	public ParticleSystem leftBackThrusters;
	public ParticleSystem rightBackThrusters;
	public ParticleSystem leftSideThrusters;
	public ParticleSystem rightSideThrusters;

	new private Rigidbody rigidbody;
	private Transform theTransform;
	private AudioSource theAudio;
	private float defaultDrag;

	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;	// Caching reference for performance
		this.theAudio = this.GetComponent<AudioSource>();
		this.rigidbody = this.GetComponent<Rigidbody>();
		this.defaultDrag = this.rigidbody.drag;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Thrust forward
		if(Input.GetKey(KeyCode.W))
		{
			this.rigidbody.AddForce(this.theTransform.forward * this.forwardThrustForce, ForceMode.Force);
		}

		// Increase drag if pressing down (S key)
		if(Input.GetKeyDown(KeyCode.S))
		{
			this.rigidbody.drag = this.defaultDrag * 2.0f;
		}
		if(Input.GetKeyUp(KeyCode.S))
		{
			this.rigidbody.drag = this.defaultDrag;
		}

		// Rotate Clockwise
		if(Input.GetKey(KeyCode.D))
		{
			this.rigidbody.AddTorque(0.0f, this.rotationalForce, 0.0f, ForceMode.Force);
		}

		// Rotate CCW
		if(Input.GetKey(KeyCode.A))
		{
			this.rigidbody.AddTorque(0.0f, -this.rotationalForce, 0.0f, ForceMode.Force);
		}


		// Play engine sound
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
		{
			this.theAudio.Play();
		}


		// Apply Particle effects

		// ...if thrusting
		if(Input.GetKeyDown(KeyCode.W))
		{
			this.leftBackThrusters.Play();
			this.rightBackThrusters.Play();
		}
		if(Input.GetKeyUp(KeyCode.W))
		{
			this.leftBackThrusters.Stop();
			this.rightBackThrusters.Stop();
		}

		// ... if going clockwise
		if(Input.GetKeyDown(KeyCode.D))
		{
			this.rightSideThrusters.Play();
		}
		if(Input.GetKeyUp(KeyCode.D))
		{
			this.rightSideThrusters.Stop();
		}

		// ... and if going CCW
		if(Input.GetKeyDown(KeyCode.A))
		{
			this.leftSideThrusters.Play();
		}
		if(Input.GetKeyUp(KeyCode.A))
		{
			this.leftSideThrusters.Stop();
		}
	}
}
