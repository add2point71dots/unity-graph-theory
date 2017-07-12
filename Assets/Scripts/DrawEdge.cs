using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawEdge : MonoBehaviour {
	public Transform start;
	public Transform end;
	private LineRenderer line;
	private CapsuleCollider collider;
	public float LineWidth;

	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer>();
		Debug.Log("line transform position is: " + line.transform.position);
//		Debug.Log("IN DRAW EDGE");
//		Debug.Log("start: " + start);
//		Debug.Log("end: " + end);

		collider = gameObject.AddComponent<CapsuleCollider>();
//        capsule.radius = LineWidth / 2;
//        capsule.center = Vector3.zero;
        collider.isTrigger = true;
        collider.direction = 2; // Z-axis for easier "LookAt" orientation
	}
	
	// Update is called once per frame
	void Update () {
		line.SetPosition(0, start.position);
		line.SetPosition(1, end.position);

//		collider.transform.position = (start.position + end.position) / 2;
		collider.height = (end.position - start.position).magnitude;
		collider.transform.LookAt(start.position);
// 		capsule.transform.LookAt(start.position);
//		capsule.height = (end.position - start.position).magnitude;


//		collider.transform.position = (start.position + end.position) / 2; // Collider is added as child object of line
        float lineLength = Vector3.Distance (start.position, end.position); // length of line
//        collider.size = new Vector3 (lineLength, 0.1f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
        Vector3 midPoint = (start.position + end.position)/2;
        collider.transform.position = midPoint; // setting position of collider object
        // Following lines calculate the angle between startPos and endPos
        float angle = (Mathf.Abs (start.position.y - end.position.y) / Mathf.Abs (start.position.x - end.position.x));
        if((start.position.y<end.position.y && start.position.x>end.position.x) || (end.position.y<start.position.y && end.position.x>start.position.x))
        {
            angle*=-1;
        }
        angle = Mathf.Rad2Deg * Mathf.Atan (angle);
//        collider.transform.Rotate (0, 0, angle);
	}
}
