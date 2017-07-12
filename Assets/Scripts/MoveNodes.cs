using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNodes : MonoBehaviour {
	GameObject grabbedObject;
	float grabbedObjectSize;

	GameObject GetMouseHoverObject ()
	{
		RaycastHit hit; 
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 

		if (Physics.Raycast (ray, out hit, 100.0f)) {
			return hit.transform.gameObject;
		}
		return null;

	}

	void TryGrabObject(GameObject grabObject)
	{
		Debug.Log("grabObject is: " + grabObject);
		if (grabObject == null || !CanGrab(grabObject)) {
			
			return;
		}

		Debug.Log("I'm here!");
						
		grabbedObject = grabObject;
		grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude;
		}
	bool CanGrab(GameObject canidate)
	{
		return canidate.GetComponent<Rigidbody> () != null;
		}
	void DropObject()
	{
		if (grabbedObject == null)
						return;


		if (grabbedObject.GetComponent<Rigidbody> () != null)
						grabbedObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			grabbedObject = null;
		}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Tryna GRAB");
			if (grabbedObject == null) {
				TryGrabObject (GetMouseHoverObject ());
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			DropObject ();
		}

		if (grabbedObject != null) 
		{
			Vector3 newPosition = gameObject.transform.position+Camera.main.transform.forward*grabbedObjectSize;
			grabbedObject.transform.position = newPosition;
		}
	
	}
}
