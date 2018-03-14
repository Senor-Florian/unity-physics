using UnityEngine;
using System.Collections;

public class UniversalGravitation : MonoBehaviour {

	private const float gravitationalConstant = 6.673e-11f;  // [m^3 s^-2 kg^-1]
	private PhysicsEngine[] physicsEngineArray;

	// Use this for initialization
	void Start () {
		physicsEngineArray = GameObject.FindObjectsOfType<PhysicsEngine>();
	}

	void FixedUpdate(){
		CalculateGravity();
	}

	//Adds the gravity factor to the engine
	void CalculateGravity(){
		foreach(PhysicsEngine physicsEngineA in physicsEngineArray){
			foreach(PhysicsEngine physicsEngineB in physicsEngineArray){
				if(physicsEngineA != physicsEngineB && physicsEngineA != this){ 	//Because objects don't apply gravitational force onto themselves
					Vector3 distanceVector = physicsEngineA.transform.position - physicsEngineB.transform.position; //Distance between the two objects
					//The following line is Newton's law of universal gravitation
					float gravityMagnitude = gravitationalConstant * physicsEngineA.mass * physicsEngineB.mass / Mathf.Pow(distanceVector.magnitude, 2f);
					Vector3 gravityFeltVector = gravityMagnitude * distanceVector.normalized;
					physicsEngineA.AddForce(-gravityFeltVector);
				}
			}
		}
	}
}
