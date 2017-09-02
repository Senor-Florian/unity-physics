using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsEngine : MonoBehaviour {

	public Vector3 velocityVector; 	// [m s^-1]
	public Vector3 netForceVector; 	// N [kg m s^-2]
	public float mass; 				// [kg]
	private List<Vector3> forceVectorList = new List<Vector3>();

	//Use this for initialization
	void Start () {
		SetupThrustTrails();
	}
  
  //FixedUpdate is used instead of Update because the former is not framerate dependant
	void FixedUpdate(){
		RenderTrails();
		UpdatePosition();
	}
  
  //Applies force to object
	public void AddForce(Vector3 forceVector){
		forceVectorList.Add(forceVector);
	}

	void UpdatePosition(){
		//Sums the forces and clears the list
		netForceVector = Vector3.zero; //
		foreach(Vector3 forceVector in forceVectorList){
			netForceVector += forceVector;
		}
		forceVectorList = new List<Vector3>();
		//Calculates the velocity and position
		Vector3 accelerationVector = netForceVector / mass;
		velocityVector += accelerationVector * Time.deltaTime;
		transform.position += velocityVector * Time.deltaTime;
	}
  
	//Code for drawing trails to show the forces that affect objects 
	public bool showTrails = true;
	private LineRenderer lineRenderer;
	private int numberOfForces;
	
	void SetupThrustTrails(){
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		lineRenderer.SetColors(Color.yellow, Color.yellow);
		lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.useWorldSpace = false;
	}
	
	void RenderTrails(){
		if (showTrails){
			lineRenderer.enabled = true;
			numberOfForces = forceVectorList.Count;
			lineRenderer.SetVertexCount(numberOfForces * 2);
			int i = 0;
			foreach(Vector3 forceVector in forceVectorList){
				lineRenderer.SetPosition(i, Vector3.zero);
				lineRenderer.SetPosition(i+1, -forceVector);
				i = i + 2;
			}
		}
		else{
			lineRenderer.enabled = false;
		}
	}
}
