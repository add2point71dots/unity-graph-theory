using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

	private GameObject node;
	private Renderer rend;
	private Color defaultColor;
	private Material material;
	private NodeController nodeController;
	
	// Update is called once per frame

	void Start () {
		node = this.gameObject;
		rend = node.GetComponent<Renderer>();
		material = rend.material;
		defaultColor = material.GetColor("_Color");
		nodeController = node.GetComponent<NodeController>();
	}

	void Update () {
		RaycastHit hit; 
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
		if (Physics.Raycast (ray, out hit, 100.0f) && hit.transform.gameObject == node) {
			if (Input.GetKeyDown ("r")) {
				TrySetColor(Color.red);
			} else if (Input.GetKeyDown ("b")) {
				TrySetColor(Color.blue);
			} else if (Input.GetKeyDown ("g")) {
				TrySetColor(Color.green);
			} else if (Input.GetKeyDown ("m")) {
				TrySetColor(Color.magenta);
			} else if (Input.GetKeyDown ("y")) {
				TrySetColor(Color.yellow);
			} else if (Input.GetKeyDown ("c")) {
				TrySetColor(Color.cyan);
			} else if (Input.GetKeyDown ("d")) {
				material.SetColor("_Color", defaultColor);
			}
		}
	}

	void TrySetColor (Color color) {

		for (int i = 0; i < nodeController.adjacentNodes.Count; i++) {
			Material adjNodeMaterial = nodeController.adjacentNodes[i].GetComponent<Renderer>().material;
			if (adjNodeMaterial.GetColor("_Color") == color) {
				Debug.Log("NOT A VALID COLORING");
				return;
			}
		}
		material.SetColor("_Color", color);
	}
}
