using UnityEngine;

public class DestroySelfOnTimeout : MonoBehaviour 
{
	[SerializeField] private float seconds;

	// Use this for initialization
	void Start () 
	{
		GameObject.Destroy(this.gameObject, this.seconds);
	}
}
