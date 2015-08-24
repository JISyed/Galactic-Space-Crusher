using UnityEngine;
using System.Collections;

public class FaceObjectAroundYAxis : MonoBehaviour 
{
	[SerializeField] private Transform target;

	private Transform theTransform;

	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		var lookPos = target.position - this.theTransform.position;
		lookPos.y = 0;
		var finalRotation = Quaternion.LookRotation(lookPos);
		this.theTransform.rotation = finalRotation;
	}
}
