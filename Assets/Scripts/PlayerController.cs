/**
	--------------------------------------------
	Player Controller
	--------------------------------------------

	Description: Allows control of main character object.

	Author(s): Jack Riales
 */

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Camera playerCamera;

	[Range(0.5f, 5f)]
	public float walkSpeed = 1f;

	[Range(1f, 10f)]
	public float runSpeed = 2f;

	[Range(-10f, -50f)]
	public float outOfBoundsYPosition = -15f;

	private Vector3 startPosition;

	void Awake() {
		if (!playerCamera) {
			playerCamera = Camera.main;
		}
		startPosition = transform.position;
	}

	void FixedUpdate() {
		// Get the world-axis input vector
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		Vector3 inputVector = new Vector3 (h * walkSpeed, 0, v * walkSpeed);

		// Get directional force based on camera orientation
		inputVector = playerCamera.transform.TransformDirection(inputVector);
		inputVector.y = 0;

		// Apply the unit directional vector and the speed vector
		//transform.localPosition += inputVector;
		GetComponent<Rigidbody> ().AddForce (inputVector, ForceMode.VelocityChange);

		// DEBUG DEBUG DEBUG
		// Reset the player's orientation
		if (transform.position.y <= outOfBoundsYPosition || Input.GetKeyDown (KeyCode.Escape))
			transform.position = startPosition;
	}

	void OnCollisionEnter() {

	}
}
