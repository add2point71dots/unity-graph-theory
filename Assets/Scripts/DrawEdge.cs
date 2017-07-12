using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawEdge : MonoBehaviour {
	public Transform start;
	public Transform end;
	private LineRenderer line;
	private CapsuleCollider capsule;
	public float LineWidth;

	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer>();
//		Debug.Log("IN DRAW EDGE");
//		Debug.Log("start: " + start);
//		Debug.Log("end: " + end);

		capsule = gameObject.AddComponent<CapsuleCollider>();
        capsule.radius = LineWidth / 2;
        capsule.center = Vector3.zero;
        capsule.isTrigger = true;
        capsule.direction = 2; // Z-axis for easier "LookAt" orientation
	}
	
	// Update is called once per frame
	void Update () {
		line.SetPosition(0, start.position);
		line.SetPosition(1, end.position);

		capsule.transform.position = start.position + (end.position - start.position) / 2;
 		capsule.transform.LookAt(start.position);
		capsule.height = (end.position - start.position).magnitude;
	}
}
