using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

	private GameObject node;
	private Renderer rend;
	private Color defaultColor;
	private Material material;
	
	// Update is called once per frame

	void Start () {
		node = this.gameObject;
		rend = node.GetComponent<Renderer>();
		material = rend.material;
		defaultColor = material.GetColor("_Color");
	}
	void Update () {
		RaycastHit hit; 
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
		if (Physics.Raycast (ray, out hit, 100.0f) && hit.transform.gameObject == node) {
			if (Input.GetKeyDown ("r")) {
				material.SetColor("_Color", Color.red);
			} else if (Input.GetKeyDown ("b")) {
				material.SetColor("_Color", Color.blue);
			} else if (Input.GetKeyDown ("g")) {
				material.SetColor("_Color", Color.green);
			} else if (Input.GetKeyDown ("m")) {
				material.SetColor("_Color", Color.magenta);
			} else if (Input.GetKeyDown ("y")) {
				material.SetColor("_Color", Color.yellow);
			} else if (Input.GetKeyDown ("c")) {
				material.SetColor("_Color", Color.cyan);
			}
		}
	}
}
