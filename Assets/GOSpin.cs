//CREATED BY HARDLYBRIEFDAN

using UnityEngine;
using System.Collections;

public class GOSpin : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector3.up, .15f);    //rotates the gameobject on the y-axis at a speed of .15units per frame
        this.transform.position = new Vector3(this.transform.position.x, Mathf.PingPong(Time.time/2f, .5f), this.transform.position.z); //sets the gameobjects position to a new y position using a sin wave
	}
}
