/**
	--------------------------------------------
	World Controller
	--------------------------------------------

	Description: Controls the world state and various settings involving levels.

	Author(s): Jack Riales
 */

using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour {

	public GameObject	levelMesh;
	public GameObject	levelMeshTopless;
	public Light		globalLight;

	void Update() {
		// Show ceiling mode when tilde is clicked
		if (Input.GetKeyDown (KeyCode.F1)) {
			if (levelMesh.GetComponent<Renderer>().enabled) {
				levelMesh.GetComponent<Renderer>().enabled = false;
				levelMeshTopless.GetComponent<Renderer>().enabled = true;
			} else {
				levelMeshTopless.GetComponent<Renderer>().enabled = false;
				levelMesh.GetComponent<Renderer>().enabled = true;
			}
		}
	}
}
