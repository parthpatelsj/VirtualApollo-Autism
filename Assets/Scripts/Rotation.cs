using UnityEngine;
using System.Collections;


public class Rotation : MonoBehaviour
{
	// Use this for initialization
	void Start () {

	}

	void Update()
	{
		transform.Rotate(new Vector3(Time.deltaTime*10,Time.deltaTime*50,0));
	}
}
	