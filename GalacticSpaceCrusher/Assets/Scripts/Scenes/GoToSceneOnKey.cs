using UnityEngine;

public class GoToSceneOnKey : MonoBehaviour 
{
	public KeyCode triggerKey = KeyCode.Return;
	public string nextScene;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(this.triggerKey))
		{
			Application.LoadLevel(this.nextScene);
		}
	}
}
