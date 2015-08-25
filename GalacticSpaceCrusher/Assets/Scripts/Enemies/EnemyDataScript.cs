using UnityEngine;

public class EnemyDataScript : MonoBehaviour 
{
	public int health;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(health <= 0)
		{
			GameObject.Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		PlayerBulletScript bulletData = other.GetComponent<PlayerBulletScript>();
		if(bulletData != null)
		{
			this.DecreaseHealth(bulletData.damageAmount);
			GameObject.Destroy(other.gameObject);
		}
	}

	void OnCollisionEnter(Collision other)
	{

	}

	private void DecreaseHealth(int decreaseAmount)
	{
		this.health -= decreaseAmount;
		if(this.health < 0)
		{
			this.health = 0;
		}
	}
}
