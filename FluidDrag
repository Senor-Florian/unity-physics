using UnityEngine;
using System.Collections;

public class FluidDrag : MonoBehaviour {

	[Range (1f, 2f)]
	public float velocityExponent;	// [none], between 1 and 2
	public float dragConstant;		// [[kg m⁻1]
	private PhysicsEngine physicsEngine;

	// Use this for initialization
	void Start () {
		physicsEngine = GetComponent<PhysicsEngine>();
	}

	void FixedUpdate(){
		Vector3 velocityVector = physicsEngine.velocityVector;
		float speed = velocityVector.magnitude; //Turns vector into scalar
		float dragMagnitude = dragConstant * Mathf.Pow(speed, velocityExponent);
		//The minus is needed because the drag's direction is opposite of the object's velocity 
		//Normalized is needed because we only need the orientation of the velocity vector
		Vector3 dragVector = dragMagnitude * (-velocityVector.normalized);
		physicsEngine.AddForce(dragVector);
	}
}
