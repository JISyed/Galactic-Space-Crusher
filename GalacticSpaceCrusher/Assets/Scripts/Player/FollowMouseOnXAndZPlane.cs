using UnityEngine;

// Thanks Byte56 
// http://gamedev.stackexchange.com/questions/75649/how-do-i-get-mouse-x-y-of-the-world-plane-in-unity

public class FollowMouseOnXAndZPlane : MonoBehaviour
{
	private static Plane XZPlane = new Plane(Vector3.up, Vector3.zero);

	private Transform theTransform;

	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.theTransform.position = FollowMouseOnXAndZPlane.GetMousePositionOnXZPlane();
	}
	
	public static Vector3 GetMousePositionOnXZPlane() 
	{
		float distance;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(XZPlane.Raycast (ray, out distance)) 
		{
			Vector3 hitPoint = ray.GetPoint(distance);
			//Just double check to ensure the y position is exactly zero
			hitPoint.y = 0;
			return hitPoint;
		}
		
		return Vector3.zero;
	}
}
