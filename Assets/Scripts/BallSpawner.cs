using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class BallSpawner : MonoBehaviour {

	public GameObject ball;
	public int numberOfBalls = 5;
	public Material[] materials;


	List<Vector3> ballPositions = new List<Vector3>();

	// Use this for initialization
	void Start () {

		//Initialize positions
		for (int i = 0; i < numberOfBalls; i++) {
			float x_coord = -4 + i * 2;
			float y_coord = 2;
			float z_coord = 10;

			Vector3 ballClone = new Vector3 (x_coord, y_coord, z_coord);
			ballPositions.Add (ballClone);

		}

		spawnBalls ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawnBalls(){
		
		for (int i = 0; i < ballPositions.Count; i++) {

			Vector3 ballPosition = ballPositions [i];
			Quaternion ballRotation = Quaternion.Euler (0, 0, 0);

			GameObject newBall = Instantiate (ball, ballPosition, ballRotation);

			newBall.transform.parent = this.transform;

			newBall.GetComponent<Renderer> ().material = materials [i];
		
		}

	}
}
