using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastForward : MonoBehaviour {
	private bool firstClicked;
	private Vector3 lineStart;
	private Vector3 lineEnd;
	public GameObject edge;

	void Start () {
		firstClicked = true;
	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) { 
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if ( Physics.Raycast (ray , out hit, 100.0f)) {
				Debug.Log("First click? " + firstClicked);
				// still a WIP
				if (firstClicked) {
					lineStart = hit.transform.position;
				} else {
					lineEnd = hit.transform.position;
					DrawEdge(lineStart, lineEnd);
				}

				firstClicked = !firstClicked;
				Debug.Log("Line start is: " + lineStart); // ensure you picked right object
				Debug.Log ("Line end is: " + lineEnd);
			}
		}  
    }

    void DrawEdge (Vector3 start, Vector3 end) {
    	Debug.Log("IN DRAWEDGE");
    	Debug.Log ("LINE GOES: " + start + " " + end);

		var points = new Vector3[2];
		points[0] = start;
		points[1] = end;

		Instantiate(edge);

		LineRenderer line = edge.GetComponent<LineRenderer>();
		line.SetPositions(points);

    }
}
