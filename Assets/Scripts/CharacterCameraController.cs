/**
	--------------------------------------------
	Character Camera Controller
	--------------------------------------------

	Description: Used to handle rotation and zoom of the main character-following camera.

	Author(s): Jack Riales
 */

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CharacterCameraController : MonoBehaviour {

	public PlayerController player;
	public Transform[] pivots;
	public float zoomFactor = 1f;
	public float zoomMax = 10f;
	public float zoomMin = 0f;
	private int _currentPivot;

	void Start() {
		if (this.transform.parent != player.transform)
			this.transform.parent = player.transform;
		if (pivots [0])
			_currentPivot = 0;
	}

	void Update() {
		// Rotate camera clockwise
		if (Input.GetKeyDown (KeyCode.E)) {
			if (_currentPivot != pivots.Length - 1)
				_currentPivot += 1;
			else
				_currentPivot = 0;
		}
		
		// Rotate camera counterclockwise
		else if (Input.GetKeyDown (KeyCode.Q)) {
			if (_currentPivot != 0)
				_currentPivot -= 1;
			else
				_currentPivot = pivots.Length - 1;
		}

		// Set transform
		if (this.transform.position != pivots[_currentPivot].position) {
			this.transform.position = pivots[_currentPivot].position;
			this.transform.rotation = pivots[_currentPivot].rotation;
		}

		// Allow for zoom using the scrollwheel
		// Optionally use the '.' and ',' because the axis control is fucked up.
		float mouseWheel = Input.GetAxis ("Mouse ScrollWheel");
		Camera camComponent = GetComponent<Camera> ();
		if (mouseWheel > 0f || Input.GetKey(KeyCode.Comma)) {
			if (camComponent.orthographicSize >= zoomMax) {
				camComponent.orthographicSize = zoomMax;
			} else
				camComponent.orthographicSize += zoomFactor;
		} 
		else if (mouseWheel < 0f || Input.GetKey(KeyCode.Period)) {
			if (camComponent.orthographicSize <= zoomMin) {
				camComponent.orthographicSize = zoomMin;
			} else
				camComponent.orthographicSize -= zoomFactor;
		}
	}
}