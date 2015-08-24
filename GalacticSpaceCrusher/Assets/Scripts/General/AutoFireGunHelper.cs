using UnityEngine;
using System.Collections;

public class AutoFireGunHelper : MonoBehaviour 
{
	[SerializeField] private float fireIntervalInSeconds;
	[SerializeField] private float startDelayInSeconds;
	[SerializeField] private bool burstsMode = false;
	[SerializeField] private int numberOfBursts = 1;
	[SerializeField] private float interburstTime;

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
			if(this.burstsMode)
			{
				// Wait
				yield return new WaitForSeconds(this.fireIntervalInSeconds);

				// Burst fire for the given amount of bursts
				for(int i = 0; i < this.numberOfBursts; i++)
				{
					// Fire!
					this.gun.Fire();
					yield return new WaitForSeconds(this.interburstTime);
				}


			}
			else
			{
				// Wait
				yield return new WaitForSeconds(this.fireIntervalInSeconds);
				// Fire!
				this.gun.Fire();
			}
		}
	}
}
