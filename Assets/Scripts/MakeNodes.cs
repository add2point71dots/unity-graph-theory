using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeNodes : MonoBehaviour {
	public GameObject node;
	public Transform nodeSpawn;

	void Update () {
		if (Input.GetButton("Fire1")) {
			print(Input.mousePosition);
            Instantiate(node, nodeSpawn.position, nodeSpawn.rotation);
        }

	}
}