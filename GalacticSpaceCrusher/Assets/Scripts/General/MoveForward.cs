using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour 
{
	public float speed;

	private Color arrowColor = new Color(0.0f, 0.5f, 1.0f);
	private Transform theTransform;
	private Vector3 newPosition;

	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform; // Caching for performance
	}
	
	// Update is called once per frame
	void Update () 
	{
		// np = op + v * t
		newPosition = this.theTransform.position;
		newPosition += (this.theTransform.forward * this.speed) * Time.deltaTime;
		this.theTransform.position = newPosition;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = this.arrowColor;
		Vector3 toVec = this.transform.position + (this.transform.forward * this.speed*0.5f);
		Gizmos.DrawLine(this.transform.position, toVec);
		Gizmos.DrawSphere(toVec, 0.1f);
	}
}
