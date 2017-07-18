using System.Collections;
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
					NodeController nodeController = hitObject.GetComponent<NodeController>();

					for (int i = 0; i < nodeController.connectedEdges.Count; i++) {
						GameObject edge = nodeController.connectedEdges[i];

						GameObject startNode = edge.GetComponent<DrawEdge>().start;
						GameObject endNode = edge.GetComponent<DrawEdge>().end;

						GameObject otherNode = (startNode == hitObject) ? endNode : startNode;
						otherNode.GetComponent<NodeController>().connectedEdges.Remove(edge);

						Destroy(edge);
					}
					Destroy(hitObject);

					for (int i = 0; i < nodeController.adjacentNodes.Count; i++) {
						NodeController adjController = nodeController.adjacentNodes[i].GetComponent<NodeController>();
						adjController.adjacentNodes.Remove(hitObject);
					}
				} else if (hitObject.tag == "Edge") {
					GameObject startNode = hitObject.GetComponent<DrawEdge>().start;
					GameObject endNode = hitObject.GetComponent<DrawEdge>().end;

					startNode.GetComponent<NodeController>().connectedEdges.Remove(hitObject);
					endNode.GetComponent<NodeController>().connectedEdges.Remove(hitObject);

					startNode.GetComponent<NodeController>().adjacentNodes.Remove(endNode);
					endNode.GetComponent<NodeController>().adjacentNodes.Remove(startNode);

					Destroy(hitObject);
				}

			}
		}
	}
}
