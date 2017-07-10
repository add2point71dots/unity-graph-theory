using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadLineTest : MonoBehaviour {
	public float pulseTime = 1.0f;
	public Transform start;
	public Transform end;
	private Renderer rend;

	void Start() {
		rend = GetComponent<Renderer>();
        rend.enabled = false;
     }
 
     void Update () {
         if (Input.GetKeyDown(KeyCode.Space)) {
             StartCoroutine(Pulse(pulseTime));
         }
     }
 
     IEnumerator Pulse (float time)
	{
		rend.enabled = true;
		Vector3 scale = transform.localScale;
 
		float timer = 0.0f;
		while (timer <= 1.0f) {
			Debug.Log("QUAD HAPPENING");
			Vector3 dir = end.position - start.position;
			float dist = dir.magnitude;
			transform.rotation = Quaternion.FromToRotation (Vector3.up, dir);
			float yScale = Mathf.PingPong (timer * 2.0f, 1.0f);
			scale.y = yScale * dist;
			transform.localScale = scale;
			transform.position = Vector3.Lerp (start.position, end.position, timer);
 
			if (timer < 0.5) {
				timer += Time.deltaTime / time;
			}
            yield return null;
         }
         rend.enabled = false;
     }
}



//public class LineTest : MonoBehaviour {
//	public float pulseTime = 1.0f;
//	public float breakDistance = 5.0f;
//	public Transform start;
//	public Transform end;
//	private bool pulsing = false;
//	private Renderer rend;
//
//	void Start() {
//		rend = GetComponent<Renderer>();
//        rend.enabled = false;
//     }
// 
//     void Update () {
//         if (Input.GetKeyDown(KeyCode.Space)) {
//             StartCoroutine(Pulse(pulseTime));
//         }
//     }
// 
//     IEnumerator Pulse(float time) {
//         if (pulsing) yield break;
//         pulsing = true;
//         rend.enabled = true;
//         Vector3 scale = transform.localScale;
//         bool broken = false;
// 
//         float timer = 0.0f;
//         while (timer <= 1.0f) {
//             Vector3 dir = end.position - start.position;
//             float dist = dir.magnitude;
//             transform.rotation = Quaternion.FromToRotation (Vector3.up, dir);
//             float yScale = Mathf.PingPong(timer * 2.0f, 1.0f);
//             scale.y = yScale * dist;
//             transform.localScale = scale;
//             transform.position = Vector3.Lerp (start.position, end.position, timer);
// 
//             if (!broken && timer > 0.5f && dist > breakDistance)
//                 broken = true;
// 
//             if (timer < 0.5 || broken)
//                 timer += Time.deltaTime / time;
//             yield return null;
//         }
//         pulsing = false;
//         rend.enabled = false;
//     }
//}
