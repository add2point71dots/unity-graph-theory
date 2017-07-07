using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastForward : MonoBehaviour {
	private bool firstClicked;
	private Vector3 lineStart;
	private Vector3 lineEnd;

	void Start () {
		firstClicked = true;
	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) { 
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if ( Physics.Raycast (ray , out hit, 100.0f)) {
				// still need to fiddle with this --> probs with a lastclicked/currentclicked
				if (firstClicked) {
					lineStart = hit.transform.position;
				} else {
					lineEnd = hit.transform.position;
				}

				firstClicked = !firstClicked;
				Debug.Log("Line start is: " + lineStart); // ensure you picked right object
				Debug.Log ("Line end is: " + lineEnd);
			}
		}  
    }
}
