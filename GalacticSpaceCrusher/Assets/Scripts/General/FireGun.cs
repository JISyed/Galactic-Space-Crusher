using UnityEngine;

// Only fires weapon along transform.forward
public class FireGun : MonoBehaviour 
{
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private Vector3 relativeSpawnPoint;
	[SerializeField] private bool isKeyControlled;
	[SerializeField] private KeyCode keyTrigger;

	private Transform theTransform;

	// Use this for initialization
	void Start () 
	{
		this.theTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(this.isKeyControlled)
		{
			if(Input.GetKeyDown(this.keyTrigger))
			{
				this.Fire();
			}
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;

		Vector3 absoluteSpawnPoint = this.GetAbsoluteSpawnPoint();

		Gizmos.DrawWireSphere(this.transform.position + absoluteSpawnPoint, 0.1f);
	}

	/// <summary>
	/// 	Fire the weapon
	/// </summary>
	public void Fire()
	{
		Vector3 absoluteSpawnPoint = this.GetAbsoluteSpawnPoint();
		GameObject.Instantiate(this.bulletPrefab, absoluteSpawnPoint, this.theTransform.rotation);
	}


	private Vector3 GetAbsoluteSpawnPoint()
	{
		return Quaternion.Euler(this.transform.rotation.eulerAngles) * this.relativeSpawnPoint;
	}


}
