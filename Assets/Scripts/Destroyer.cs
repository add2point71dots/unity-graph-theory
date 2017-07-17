﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			RaycastHit hit; 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			if (Physics.Raycast (ray , out hit, 100.0f)) {
				GameObject hitObject = hit.transform.gameObject;
				if (hitObject.tag == "Node") {
					Debug.Log("I'm DESTROYING A NODE");
					NodeController nodeController = hitObject.GetComponent<NodeController>();
					for (int i = 0; i < nodeController.connectedEdges.Count; i++) {
						Destroy(nodeController.connectedEdges[i]);
					}
				}
				Destroy(hit.transform.gameObject);
				Debug.Log("I've HIT SOMETHING");
			}
		}
	}
}
