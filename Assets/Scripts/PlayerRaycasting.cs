using UnityEngine;
using System.Collections;

public class PlayerRaycasting : MonoBehaviour {

	public Camera camera;
	public float distanceToSee;
	RaycastHit whatIHit;

	Renderer rend;

	public Shader shader1;
	public Shader shader2;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		RaycastHit rayHit;

		if (Physics.Raycast (new Ray (camera.transform.position, camera.transform.rotation * Vector3.forward), out rayHit)) {
	
			GameObject targetHit = rayHit.collider.gameObject;

			if (targetHit.CompareTag ("PoolBall")) {

				if (targetHit.GetComponent<Renderer> ().material.shader == shader1) {
					targetHit.GetComponent<Renderer> ().material.shader = shader2;
				}
					
					
			}
		}
		
		
	}
		
		
}
