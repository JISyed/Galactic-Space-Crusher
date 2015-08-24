using UnityEngine;
using System.Collections;

public class FaceObjectAroundYAxis : MonoBehaviour 
{
	[SerializeField] private string targetTagName;

	private Transform theTransform;
	private Transform target;

	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
		this.target = GameObject.FindGameObjectWithTag(this.targetTagName).transform;
		if(this.target == null)
		{
			Debug.LogError("Target with tag \"" + this.targetTagName + "\" could not be found!");
		}
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
