using UnityEngine;
using UnityEngine.UI;

public class PlayerDataScript : MonoBehaviour 
{
	public int health = 500;
	[SerializeField] private UnityEngine.UI.Text healthDisplay;

	// Use this for initialization
	void Start () 
	{
		this.healthDisplay.text = this.health.ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(this.health <= 0)
		{
			Application.LoadLevel("scene_GameOver");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		EnemyBulletScript bulletData = other.GetComponent<EnemyBulletScript>();
		if(bulletData != null)
		{
			this.DecreaseHealth(bulletData.damageAmount);
			GameObject.Destroy(other.gameObject);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		//Debug.Log("Collision");
	}

	private void DecreaseHealth(int decreaseAmount)
	{
		this.health -= decreaseAmount;
		if(this.health < 0)
		{
			this.health = 0;
		}
		this.healthDisplay.text = health.ToString();
	}
}
