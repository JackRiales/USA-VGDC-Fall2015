/**
	--------------------------------------------
	Character Camera Controller
	--------------------------------------------

	Description: Used to handle rotation and zoom of the main character-following camera.

	Author(s): Jack Riales
 */

using UnityEngine;
using System.Collections;

public class CharacterCameraController : MonoBehaviour {

	public PlayerController player;
	public Transform[] pivots;
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
	}
}