using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script adds an initial speed and spin to an object as well as the Magnus effect 

public class MagnusEffect : MonoBehaviour {

	public Vector3 startVelocity;
	public Vector3 startAngularVelocity;
	public float magnusConstant;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.velocity = startVelocity;
		rigidBody.angularVelocity = startAngularVelocity;
	}
	
	void FixedUpdate () {
		rigidBody.AddForce(magnusConstant * Vector3.Cross(rigidBody.angularVelocity, rigidBody.velocity));
	}
}
