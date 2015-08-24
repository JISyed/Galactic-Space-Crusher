using UnityEngine;
using System.Collections;

public class AutoRotate : MonoBehaviour 
{
	[SerializeField] private Vector3 axialRotations;

	private Transform theTransform;

	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.theTransform.Rotate(this.axialRotations * Time.deltaTime);
	}
}
