using UnityEngine;

public class DecendBulletToYZero : MonoBehaviour 
{
	[SerializeField] private float decentionSpeed;

	private Transform theTransform;

	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(this.theTransform.position.y <= 0.0f)
		{
			// Disable the script
			this.enabled = false;
		}
		else
		{
			Vector3 newPosition = this.theTransform.position;
			newPosition += (Vector3.down * this.decentionSpeed) * Time.deltaTime;
			this.theTransform.position = newPosition;
		}
	}
}
