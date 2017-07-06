using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeNodes : MonoBehaviour {
	public GameObject node;
	public Transform nodeSpawn;

	void Update () {
		if (Input.GetKeyDown("space")) {
			Vector3 newNodePosition = new Vector3 (nodeSpawn.position.x, Random.Range (0.5f, 1.6f), nodeSpawn.position.z);
			Collider[] nearbyNodes = Physics.OverlapSphere(newNodePosition, 0.2f);
			Debug.Log (nearbyNodes.Length);

			if (nearbyNodes.Length == 0) {
				Instantiate(node, newNodePosition, nodeSpawn.rotation);
			}
        }
	}
}