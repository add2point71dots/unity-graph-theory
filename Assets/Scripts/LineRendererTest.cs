using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTest : MonoBehaviour {
	public float pulseTime = 1.0f;
	public Transform start;
	public Transform end;
	private Renderer rend;
	private LineRenderer line;

	void Start() {
		rend = GetComponent<Renderer>();
		line = GetComponent<LineRenderer>();
        rend.enabled = false;
     }
 
     void Update () {
		line.SetPosition(0, start.position);
		line.SetPosition(1, end.position);

         if (Input.GetKeyDown(KeyCode.Space)) {
//             StartCoroutine(Pulse(pulseTime));
			rend.enabled = true;
         }
     }
 
     IEnumerator Pulse (float time) {
		line.SetPosition(0, start.position);
		line.SetPosition(1, end.position);
		rend.enabled = true;

		Debug.Log("HAPPENING");

        yield return null;
//        rend.enabled = false;
     }
}
