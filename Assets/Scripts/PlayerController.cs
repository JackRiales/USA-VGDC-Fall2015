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

	public float walkSpeed = 1f;
	public float runSpeed = 2f;

	void Update() {
		GetComponent<Rigidbody>().AddForce(new Vector3 (Input.GetAxis("Horizontal") * walkSpeed, 0, Input.GetAxis("Vertical") * walkSpeed));
	}
}
