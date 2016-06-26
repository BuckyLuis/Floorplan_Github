using UnityEngine;
using System.Collections;
using TeamUtility.IO;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]

public class FPController : MonoBehaviour 
{

	public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;
	private bool grounded = false;

	private Rigidbody rb;
	public GameObject cam;
	private MouseLook camScript;



	void Awake () 
	{
		rb = GetComponent<Rigidbody>();
		camScript = cam.GetComponent<MouseLook>();

		rb.freezeRotation = true;
		rb.useGravity = false;
	}

	void FixedUpdate () 
	{
		transform.rotation = Quaternion.Euler (0, camScript.rotYcur, 0);

		if (grounded) 
		{
			// Calculate how fast we should be moving
			Vector3 targetVelocity = new Vector3(InputManager.GetAxis("Horizontal"), 0, InputManager.GetAxis("Vertical"));
			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= speed;

			// Apply a force that attempts to reach our target velocity
			Vector3 velocity = rb.velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			rb.AddForce(velocityChange, ForceMode.VelocityChange);

			// Jump
			if (canJump && InputManager.GetButtonDown("Jump")) 
			{
				rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
			}
		}

		// We apply gravity manually for more tuning control
		rb.AddForce(new Vector3 (0, -gravity * rb.mass, 0));

		grounded = false;
	}

	void OnCollisionStay ()
	{
		grounded = true;    
	}

	float CalculateJumpVerticalSpeed () 
	{
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}
}


// from here:
//http://wiki.unity3d.com/index.php?title=RigidbodyFPSWalker