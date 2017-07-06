using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float rotateSpeed;
	public float movementSpeed;

	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 rotation = new Vector3 (0.0f, moveHorizontal, 0.0f);
		Vector3 forwardMovement = new Vector3 (0.0f, 0.0f, moveVertical);

		transform.Rotate (rotation * rotateSpeed * Time.deltaTime);
		transform.Translate(forwardMovement * movementSpeed);
	}
}
