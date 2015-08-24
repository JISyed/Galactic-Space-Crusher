using UnityEngine;
using System.Collections;

public class AutoFireGunHelper : MonoBehaviour 
{
	[SerializeField] private float fireIntervalInSeconds;
	[SerializeField] private float startDelayInSeconds;

	private FireGun gun;
	private bool keepRunning = true;

	// Use this for initialization
	IEnumerator Start () 
	{
		this.gun = this.GetComponent<FireGun>();
		yield return new WaitForSeconds(this.startDelayInSeconds);
		StartCoroutine(AutoFire());
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnDestroy()
	{
		this.keepRunning = false;
	}

	private IEnumerator AutoFire()
	{
		while(keepRunning)
		{
			// Wait
			yield return new WaitForSeconds(this.fireIntervalInSeconds);
			// Fire!
			this.gun.Fire();
		}
	}
}
