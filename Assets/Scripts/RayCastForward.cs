using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastForward : MonoBehaviour {
	private bool firstClicked;
	private Transform lineStart;
	private Transform lineEnd;
	public GameObject edge;

	void Start () {
		firstClicked = true;
	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) { 
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if (Physics.Raycast (ray , out hit, 100.0f)) {
				Debug.Log("First click? " + firstClicked);
				Debug.Log("hit is: " + hit.transform);
				// still a WIP
				if (firstClicked) {
//					lineStart = hit.transform.position;
					lineStart = hit.transform;
				} else {
//					lineEnd = hit.transform.position;
					lineEnd = hit.transform;
//					DrawEdge(lineStart, lineEnd);

					GameObject go = Instantiate(edge) as GameObject;
					DrawEdge drawEdge = go.GetComponent<DrawEdge>();
					drawEdge.start = lineStart;
					drawEdge.end = lineEnd;
		

					
				}

				firstClicked = !firstClicked;
				Debug.Log("Line start is: " + lineStart); // ensure you picked right object
				Debug.Log ("Line end is: " + lineEnd);
			}
		}  
    }

//    void DrawEdge (Vector3 start, Vector3 end) {
//    	Debug.Log("IN DRAWEDGE");
//    	Debug.Log ("LINE GOES: " + start + " " + end);
//
//		var points = new Vector3[2];
//		points[0] = start;
//		points[1] = end;
//
//		Instantiate(edge);
//
//		LineRenderer line = edge.GetComponent<LineRenderer>();
//		line.SetPositions(points);
//
//    }
}
