using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

	public Transform view;
	public float smoothness;
	float distance;
	// Use this for initialization
	void Start () {
		distance = Vector3.Distance(transform.position, view.position);
	}

	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, view.transform.forward * distance, Time.deltaTime * smoothness);
		transform.LookAt(view.position + 2*view.transform.forward*distance);
	}
}
